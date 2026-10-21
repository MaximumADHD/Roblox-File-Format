import argparse
import json
import os
import re
import sys
import time
from pathlib import Path
from urllib.error import HTTPError, URLError
from urllib.request import Request, urlopen

ROOT = Path(__file__).resolve().parent.parent
VERSION_FILE = ROOT / "Generated" / "Version.txt"

GENERATORS = (
    ("GenerateClasses", ROOT / "Scripts" / "GenerateClasses.luau", "// Auto-generated list of creatable Roblox classes."),
    ("GenerateEnums", ROOT / "Scripts" / "GenerateEnums.luau", "// Auto-generated list of Roblox enums."),
)

VERSION_PATTERN = re.compile(r"\A\d+\.\d+\.\d+\.\d+\Z")
API_ROOT = "https://apis.roblox.com/cloud/v2"
TASK_TIMEOUT_SECONDS = 600

UNIVERSE_ID = 10772183580
PLACE_ID = 70880851267260
PLACE_VERSION = 5

def read_json(url: str, headers: dict[str, str] | None = None, data: bytes | None = None) -> dict:
    request = Request(url, data=data, headers=headers or {}, method="POST" if data else "GET")

    try:
        with urlopen(request, timeout=30) as response:
            payload = json.loads(response.read().decode("utf-8"))
    except (HTTPError, URLError, TimeoutError, json.JSONDecodeError) as error:
        raise RuntimeError(f"Request failed for {url}: {error}") from error

    if not isinstance(payload, dict):
        raise RuntimeError(f"Expected a JSON object from {url}.")
    
    return payload

def check_version() -> int:
    api_key = os.environ.get("RBX_API_KEY")

    if not api_key:
        raise RuntimeError("RBX_API_KEY is required to read the Roblox version.")

    task_path = create_task("return version()", api_key)
    version = wait_for_task(task_path, api_key, "Version check")

    if not VERSION_PATTERN.fullmatch(version):
        raise RuntimeError(f"Luau version() returned an invalid version: {version!r}")

    current = VERSION_FILE.read_text(encoding="utf-8-sig").strip() if VERSION_FILE.exists() else ""
    changed = version != current

    print(f"Generated version: {current or '<missing>'}")
    print(f"Current version: {version}")
    print("Generation required." if changed else "Generated files are current.")

    github_output = os.environ.get("GITHUB_OUTPUT")

    if github_output:
        with open(github_output, "a", encoding="utf-8", newline="\n") as output:
            output.write(f"version={version}\n")
            output.write(f"changed={'true' if changed else 'false'}\n")

    return 0

def create_task(source: str, api_key: str) -> str:
    url = (
        f"{API_ROOT}/universes/{UNIVERSE_ID}/places/{PLACE_ID}"
        f"/versions/{PLACE_VERSION}/luau-execution-session-tasks"
    )

    body = json.dumps({"script": source}).encode("utf-8")

    payload = read_json(
        url,
        headers={"x-api-key": api_key, "Content-Type": "application/json"},
        data=body,
    )

    task_path = payload.get("path")

    if not isinstance(task_path, str) or not task_path:
        raise RuntimeError("Roblox did not return a task path.")
    
    return task_path

def wait_for_task(task_path: str, api_key: str, generator_name: str) -> str:
    task_url = f"{API_ROOT}/{task_path.lstrip('/')}?view=FULL"
    deadline = time.monotonic() + TASK_TIMEOUT_SECONDS

    while time.monotonic() < deadline:
        task = read_json(task_url, headers={"x-api-key": api_key})
        state = task.get("state")

        if state == "COMPLETE":
            results = task.get("output", {}).get("results", [])

            if len(results) != 1 or not isinstance(results[0], str):
                raise RuntimeError(f"{generator_name} task completed without one source result.")
            
            print(f"{generator_name} completed ({len(results[0])} characters).")
            return results[0]

        if state in {"FAILED", "CANCELLED"} or task.get("error"):
            raise RuntimeError(f"{generator_name} task failed: {task.get('error') or state}")

        time.sleep(3)

    raise RuntimeError(f"Timed out waiting for {generator_name} after {TASK_TIMEOUT_SECONDS} seconds.")

def source_for_version(path: Path, version: str) -> str:
    source = path.read_text(encoding="utf-8-sig")
    first_line, separator, remainder = source.partition("\n")

    if not separator or not first_line.startswith("--!"):
        raise RuntimeError(f"{path.name} must start with a Luau directive.")

    version_function = f'local function version() return "{version}" end\n'
    return first_line + "\n" + version_function + remainder

def generate(version: str) -> int:
    if not VERSION_PATTERN.fullmatch(version):
        raise RuntimeError("Version must have the form major.minor.patch.build.")

    api_key = os.environ.get("RBX_API_KEY")

    if not api_key:
        raise RuntimeError("RBX_API_KEY is required to run Roblox Cloud Luau tasks.")

    generated_sources = []

    for generator_name, source_path, expected_header in GENERATORS:
        source = source_for_version(source_path, version)
        task_path = create_task(source, api_key)
        generated = wait_for_task(task_path, api_key, generator_name)

        if not generated.startswith(expected_header):
            raise RuntimeError(f"{generator_name} returned an invalid source header.")
        
        generated_sources.append(generated)

    for (generator_name, _, _), generated in zip(GENERATORS, generated_sources):
        output_name = "Classes.cs" if generator_name == "GenerateClasses" else "Enums.cs"
        output_path = ROOT / "Generated" / output_name
        output_path.write_text(generated, encoding="utf-8", newline="\n")

    VERSION_FILE.write_text(version + "\n", encoding="utf-8", newline="\n")
    print(f"Updated generated sources to Roblox version {version}.")

    return 0

def main() -> int:
    parser = argparse.ArgumentParser()
    commands = parser.add_subparsers(dest="command", required=True)
    commands.add_parser("check-version")
    generate_parser = commands.add_parser("generate")
    generate_parser.add_argument("--version", required=True)
    arguments = parser.parse_args()

    try:
        if arguments.command == "check-version":
            return check_version()
        
        return generate(arguments.version)
    except (OSError, RuntimeError) as error:
        print(error, file=sys.stderr)
        return 1

if __name__ == "__main__":
    raise SystemExit(main())