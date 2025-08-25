# Video: [brk447-01-Initial Setup.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:02

# Deploying Demo Models and Configuring the Local App — User Manual

This manual guides you through deploying the two models used in the demo, obtaining the required endpoints/keys, configuring your local application with the AI Foundry parameter, and verifying the deployments in the Azure Portal. Follow the steps in order to reproduce the demo.

---

## Overview
Duration: ~00:03:00 (timestamps refer to the source video)

Goal: Deploy two models (chat/text generation and embeddings) used by the demo, configure your local app to use them, and verify the deployments in the Azure Portal.

Quick prerequisites (install before starting)
- Azure CLI (az) and an Azure account  
- Access to the demo repository and any included deployment scripts (e.g., deploy scripts in the repo)  
- A code editor to edit local scripts and user secrets  
- .NET SDK if the demo app is a .NET app (for dotnet user-secrets and dotnet run)  
- Browser to access the Azure Portal and the running application

Tip: Use the correct tenant so you operate in the intended subscription (see Step 1).

---

## Step-by-step Instructions

The steps below follow the flow shown in the video. Each step includes the relevant video timestamp for reference.

### 1) Login to Azure with the correct tenant
Timestamp: 00:00:13 — 00:00:31

1. Open a terminal.
2. Authenticate with the tenant that contains the target subscription:
   - Example:
     az login --tenant <tenant-id>
3. Confirm you’re using the intended subscription (optional):
   - Example:
     az account show
     az account set --subscription <subscription-id>

Warnings:
- Use the tenant id shown for the Cloud Advocate or the tenant specified for your demo instance.
- If you have multiple subscriptions, ensure you set the correct subscription before creating resources.

---

### 2) Run the deployment to create the resource group and resources
Timestamp: 00:00:31 — 00:00:58

1. From your demo repository, run the provided deployment command or script that creates the resource group and the Azure resources:
   - Example placeholders (use the command from the repo):
     ./deploy.sh
     OR
     az deployment group create --resource-group <rg-name> --template-file <template.json> [...]
2. Wait for the process to complete. The video indicates this can take ~2 minutes.
3. When finished, the CLI will output JSON that includes resource IDs, keys, and endpoints.
   - Save or copy any relevant values shown in that JSON (resource IDs, keys, names).

Tip:
- Use the CLI output's JSON to copy values exactly. The Azure CLI supports output formats:
  - az ... --output json
  - az ... --query "<json-path>" -o tsv

---

### 3) Show endpoint and foundry/account name, update the local script, and get a connection string
Timestamp: 00:00:58 — 00:01:37

1. Use the demo’s helper command or Azure CLI to display the endpoint and the "foundry" (account) name:
   - If the repo includes a helper, run it. Otherwise, find the endpoint in the portal or with the CLI.
   - Example CLI (adjust per resource type):
     az resource show --resource-group <rg> --name <resourceName> --resource-type "Microsoft.CognitiveServices/accounts" --query properties.endpoint -o tsv
2. Copy the returned endpoint and the account/foundry name exactly.
3. Open the small script provided in the repo (common names: set-config.sh, get-connection-string.sh, or update-foundry-config) in your editor.
4. Insert or update values for:
   - Resource group name
   - Account/foundry/resource name
   - Any other required values (endpoint, region)
5. Run the script. It will produce a connection string or the combined parameter value you will use in the app.

Tip:
- Keep this connection string and keys private. Store them securely (see user secrets below).

---

### 4) Start the app and provide the AI Foundry parameter (save to user secrets)
Timestamp: 00:01:37 — 00:02:14

1. Start your app locally (the demo typically uses dotnet run from the project root or another start command shown in the repo):
   - Example:
     dotnet run
     OR
     npm start
2. On first run, the dashboard will prompt for the AI Foundry parameter (the connection string produced in Step 3).
3. Paste the connection string into the dashboard field where prompted.
4. Save the value to user secrets (the dashboard may offer an explicit "Save to user secrets" button). This persists the value so the app can run without prompting again.
   - Alternative manual command (for .NET apps):
     dotnet user-secrets set "AI:Foundry" "<connection-string>"
5. Once saved, browse the running application and test features such as product browsing and semantic search.

Tip:
- If you prefer CLI, use dotnet user-secrets to set and verify secrets. To view:
  dotnet user-secrets list

Warning:
- Do not commit user secrets or connection strings into source control.

---

### 5) Edit user secrets to point to a different resource (switching resources)
Timestamp: 00:02:18 — 00:02:39

1. If you need to switch to a different resource:
   - Open the application host/project settings (or use dotnet user-secrets).
2. Locate the AI Foundry entry in user secrets.
   - Delete or remove the current value.
   - Add the updated value when you wish to point to the new resource.
   - Example CLI:
     dotnet user-secrets remove "AI:Foundry"
     dotnet user-secrets set "AI:Foundry" "<new-connection-string>"
3. Restart the app so it picks up the updated value.
4. Re-open the dashboard and verify it no longer prompts (or accepts the new value).

Tip:
- If you get errors after changing secrets, restart your development server and clear browser caches that might hold previous state.

---

### 6) Verify the deployments in the Azure Portal (Azure OpenAI / OpenAI resource)
Timestamp: 00:02:39 — 00:03:00

1. Open the Azure Portal (https://portal.azure.com).
2. Navigate to the Resource Group you created in Step 2.
3. Open the Azure OpenAI (or OpenAI) resource inside that resource group.
4. Open the Deployments list. Confirm the expected deployments exist:
   - GPT-4o-mini (chat / text generation)
   - ADI O2 (embeddings)
5. In the resource page, locate and copy:
   - Endpoint
   - Keys (Primary or Secondary key)
   Use these values to verify or re-populate your connection string if needed.

Tip:
- In the portal you can copy endpoint and keys with the built-in copy buttons. Use the Primary key for initial testing; rotate keys if needed.

---

### 7) Test the running app and semantic search
Timestamps referenced: 00:01:37 onward

1. With the app running and the AI Foundry parameter saved:
   - Browse the app UI.
2. Use the semantic search feature (or demo-specific features) to confirm:
   - The app sends requests to the deployed models.
   - Results are returned and displayed as expected.
3. If you encounter errors, consult the app logs in the terminal where you ran the app. Common issues:
   - Missing or incorrect AI Foundry parameter
   - Wrong endpoint or key
   - Subscription/region mismatch

---

## Helpful Tips and Warnings

- Tip: Always confirm the tenant and subscription before creating resources to avoid accidental resource creation in an unintended subscription.
- Tip: Use the Azure Portal to visually verify deployments if you’re unsure about CLI output.
- Tip: Use dotnet user-secrets for local secret storage on .NET projects; it keeps secrets out of source control and is preferred for local development.
- Warning: Never commit or share keys, connection strings, or other secrets in source control or public channels.
- Warning: Resource creation and provisioning can take a few minutes — be patient and wait for the CLI/portal to report completion before copying outputs.

---

Timestamps reference:
- Intro & Prerequisites: 00:00:00.360 — 00:00:09.688  
- Login and prepare: 00:00:13.360 — 00:00:31.316  
- Create resource group & capture output: 00:00:31.316 — 00:00:58.409  
- Get endpoint & foundry name, update script: 00:00:58.409 — 00:01:37.120  
- Dashboard prompt & save to user secrets: 00:01:37.120 — 00:02:14.440  
- Edit user secrets for different resource: 00:02:18.160 — 00:02:39.848  
- Inspect resource group & Azure OpenAI deployments: 00:02:39.848 — 00:03:00.480

This manual should enable you to reproduce the demo: deploy the models, configure your app, and verify the deployments. If any repo-provided scripts or commands differ from the examples above, follow the commands included in the demo repository, substituting your resource names and tenant/subscription IDs where appropriate.