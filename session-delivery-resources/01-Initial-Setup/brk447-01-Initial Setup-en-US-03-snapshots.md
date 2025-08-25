# Video: [brk447-01-Initial Setup.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:02

# Deploying Demo Models & Configuring Local App — User Manual

This manual guides you through deploying the two models used in the demo, configuring your local application to use them, and verifying the deployments in the Azure Portal. Each major action includes clear, step-by-step instructions and references to the video timeline for context.

---

## Overview

Duration: ~3 minutes (00:00:00.360 — 00:03:00.480)

Goal: Deploy two Azure OpenAI models used by the demo (a chat/text-generation model and an embeddings model), obtain the necessary endpoints and keys, configure your local app with the AI Foundry connection string, and verify everything is working (including semantic search).

Prerequisites (high level):
- Azure CLI installed and configured
- Access to the target Azure tenant and subscription
- Local project files/scripts used in the demo (scripts to create resources and to generate the connection string)
- A web browser to open the Azure Portal and the running demo app

Tip: Keep your tenant ID, subscription access, and any scripts provided by the demo handy before you start.

---

## Step-by-step Instructions

Each step below is mapped to the relevant moment in the demo video for quick reference.

### 1) Log in to Azure (authenticate to tenant)  
Timestamp: 00:00:13.360 — 00:00:31.316

1. Open a terminal.
2. Authenticate to the correct Azure tenant using:
   ```
   az login --tenant <tenant-id>
   ```
3. Confirm you are targeting the correct subscription (if needed):
   ```
   az account show
   az account set --subscription <subscription-id>
   ```

Tip: Use the `--tenant` switch to ensure you sign into the Cloud Advocate or target tenant shown in the demo.

Snapshot:  
![Azure CLI login prompt at 00:00:13.360](./snapshot-00-00-13-360.png)

---

### 2) Create the resource group / run the scripted deployment  
Timestamp: 00:00:31.316 — 00:00:58.409

1. Run the provided deployment command or script that creates the resource group and Azure resources used by the demo (this is typically a script or `az deployment` command included with the demo).
   - Example (actual command will depend on the demo's script):
     ```
     ./deploy-resources.sh --resource-group DemoRG --location eastus
     ```
   - Or a direct Azure CLI example:
     ```
     az group create --name DemoRG --location eastus
     # then run the deployment script that the demo provided
     ```
2. Wait for completion. The demo shows this step taking ~2 minutes.
3. When the script finishes, capture the JSON output shown in the console. It typically includes resource IDs, keys and other outputs you will need.

Warning: Do not share keys or connection strings. Treat the output JSON securely.

Snapshot:  
![Resource group creation output JSON at 00:00:31.316](./snapshot-00-00-31-316.png)

---

### 3) Retrieve endpoint and 'foundry' (account) name, update local script, and generate connection string  
Timestamp: 00:00:58.409 — 00:01:37.120

1. Run the CLI command (or view the deployment output) that shows the endpoint and the "foundry" / account name for the AI resource.
   - Example hint commands (actual command depends on the demo resource):
     ```
     az resource show --ids <resource-id> --query properties
     ```
2. Copy the foundry/account name and endpoint exactly as shown.
3. Open the small local script supplied with the demo (the script that generates the connection string).
   - Edit placeholders like `RESOURCE_GROUP`, `ACCOUNT_NAME`, or similar to match the values you copied.
   - Save the file.
4. Run the script to produce the connection string:
   ```
   ./generate-connection-string.sh
   ```
   or
   ```
   python generate_connection_string.py
   ```
5. Copy the resulting connection string to your clipboard.

Tip: Use copy/paste helpers from the CLI/portal when available to avoid typos.

Snapshot:  
![Endpoint and foundry name shown in console at 00:00:58.409](./snapshot-00-00-58-409.png)

---

### 4) Paste AI Foundry parameter into the app dashboard and save to user secrets  
Timestamp: 00:01:37.120 — 00:02:14.440

1. Start the local app (as the demo instructs).
2. Open the app dashboard in your browser.
   - The dashboard will prompt for a missing AI Foundry parameter on first-run.
3. Paste the connection string produced earlier into the dashboard field for AI Foundry.
4. Save the value. The demo saves it into user secrets so the app persists the configuration.
   - GUI method: Use the dashboard's "Save" or "Persist" option (if provided).
   - CLI method (for .NET user-secrets example):
     ```
     dotnet user-secrets set "AI:Foundry" "<connection-string>"
     ```
5. Restart the app if required, then browse the app and test features like semantic search.

Tip: After saving to user secrets, the setting persists locally for the project and avoids re-entering it each time.

Snapshot:  
![Dashboard prompting for AI Foundry value at 00:01:37.120](./snapshot-00-01-37-120.png)

---

### 5) Edit user secrets to switch resources (delete, re-add)  
Timestamp: 00:02:18.160 — 00:02:39.848

1. If you need to point the app to a different resource:
   - Open your project's user secrets editor or the stored secrets file.
   - Locate the AI Foundry entry (e.g., key name `AI:Foundry` or similar).
   - Delete or update the value.
2. Run the app locally again and re-add the new connection string (same process as Step 4).

Tip: Managing user secrets via CLI or your IDE can be easier than directly editing JSON files. Always verify the key name expected by the app.

Snapshot:  
![Editing user secrets to update AI Foundry at 00:02:18.160](./snapshot-00-02-18-160.png)

---

### 6) Verify deployments in the Azure Portal (OpenAI/Azure OpenAI resource)  
Timestamp: 00:02:39.848 — 00:03:00.480

1. Open the Azure Portal (portal.azure.com).
2. Navigate to the resource group you created (e.g., DemoRG).
3. Open the Azure OpenAI (or OpenAI) resource within the group.
4. Open the Deployments list and verify the expected deployments are present:
   - GPT-4o-mini (chat / text generation)
   - ADI O2 (or the embeddings model used by the demo)
5. Copy the endpoint and keys from the resource's "Keys and Endpoint" or equivalent blade if you need them separately.

Warning: Keep endpoint keys and API keys secret. Rotate keys following your security policies if they are exposed.

Snapshot:  
![Azure OpenAI deployments listing GPT-4o-mini and ADI O2 at 00:02:39.848](./snapshot-00-02-39-848.png)

---

## Embedded Snapshots / Images

The images below are placeholders showing where to embed screenshots captured from the video. Replace each placeholder with the actual frame image extracted at the timestamp indicated.

- ![00:00:00.360 — Intro & pre-run checklist](./snapshot-00-00-00-360.png)
- ![00:00:13.360 — az login with tenant shown](./snapshot-00-00-13-360.png)
- ![00:00:31.316 — Resource group creation JSON output](./snapshot-00-00-31-316.png)
- ![00:00:58.409 — Endpoint & foundry values shown](./snapshot-00-00-58-409.png)
- ![00:01:37.120 — Dashboard prompting for AI Foundry](./snapshot-00-01-37-120.png)
- ![00:02:18.160 — Editing project user secrets](./snapshot-00-02-18-160.png)
- ![00:02:39.848 — Azure OpenAI deployments list / Keys & Endpoint](./snapshot-00-02-39-848.png)

Tip: Use the Snapshots list at the end of this manual to extract frames. The filenames above are suggested placeholders and should match the actual extracted images.

---

## Snapshots

[00:00:00.360]  
[00:00:13.360]  
[00:00:31.316]  
[00:00:58.409]  
[00:01:37.120]  
[00:02:18.160]  
[00:02:39.848]