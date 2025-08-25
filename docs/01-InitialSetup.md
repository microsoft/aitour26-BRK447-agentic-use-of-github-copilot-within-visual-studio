<!--
	Canonical infra-only deployment guide for AI Foundry (Cognitive Services / OpenAI)
	Created: 2025-08-22
	This file provides prerequisites (including Visual Studio 2022 and Docker Desktop) and
	the minimal subscription-scoped deployment steps for demo usage.
-->

# Infra-only deploy (AI Foundry) — step-by-step

This document describes the prerequisites needed to run the demo and the subscription-scoped steps to deploy the AI Foundry resources used by the sample apps.

## Prerequisites

Ensure you have the following installed before continuing (official download pages provided):

- Visual Studio 2022 (recommended for opening the full solution): [https://visualstudio.microsoft.com/vs/](https://visualstudio.microsoft.com/vs/)
- Docker Desktop (for building images or running container tools locally): [https://www.docker.com/products/docker-desktop/](https://www.docker.com/products/docker-desktop/)
- PowerShell (pwsh) — cross-platform shell: [https://learn.microsoft.com/powershell/](https://learn.microsoft.com/powershell/)
- Azure CLI (`az`) — used for deployment and resource operations: [https://learn.microsoft.com/cli/azure/install-azure-cli](https://learn.microsoft.com/cli/azure/install-azure-cli)
- .NET 9 SDK — required to build/run the .NET services in this repo: [https://dotnet.microsoft.com/en-us/download/dotnet/9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

Authenticate to Azure before running subscription-scoped deployments:

```bash
az login
```

or for a specific tenant use:

```bash
az login --tenant <tenantid>
```

## Step-by-step deploy (manual)

If you prefer to run each step manually, use the commands below.

## Deploy AI Foundry (subscription-scoped)

Run from the repository root (example uses `eastus2` and environment `brk447demo`):

```pwsh
az deployment sub create --location eastus2 --template-file infra/main.bicep --parameters environmentName=brk447demo location=eastus2
```

This creates a resource group `rg-<env>` and an Azure Cognitive Services account (OpenAI kind) with deployments `chat` and `embeddings`.

## Inspect outputs and retrieve keys

Get the subscription deployment outputs to locate the resource group and account name:

```pwsh
az deployment sub show --name main --query "properties.outputs" -o json
```

Use the account name and resource group in the following snippet to print a connection string in the format `Endpoint=...;Key=...;`:

```pwsh
$rg = 'rg-yourenv'
$accountName = 'aifoundry-xxxx'

$keysJson = az cognitiveservices account keys list -g $rg -n $accountName -o json | ConvertFrom-Json
if ($null -ne $keysJson.primaryKey) { $primaryKey = $keysJson.primaryKey } elseif ($null -ne $keysJson.key1) { $primaryKey = $keysJson.key1 } else { Write-Error 'No key found'; exit 1 }
$endpoint = az cognitiveservices account show -g $rg -n $accountName --query "properties.endpoint" -o tsv
Write-Output "Endpoint=$endpoint;Key=$primaryKey;"
```

There's a helper script at `infra/get-ai-connection.ps1` that automates the above steps and prints the connection string.

## (Optional) Assign a role to a principal

If you need to grant a principal access to the Cognitive Services account, run:

```pwsh
$principalId = '<principalId>'
$subscriptionId = az account show --query id -o tsv
$scope = "/subscriptions/$subscriptionId/resourceGroups/$rg/providers/Microsoft.CognitiveServices/accounts/$accountName"
$roleDefinitionId = '/subscriptions/' + $subscriptionId + '/providers/Microsoft.Authorization/roleDefinitions/5e0bd9bd-7b93-4f28-af87-19fc36ad61bd'
az role assignment create --assignee-object-id $principalId --role $roleDefinitionId --scope $scope
```

## Cleanup

To remove the created resource group and deployment record:

```pwsh
$rg = 'rg-yourenv'
az group delete -n $rg --yes --no-wait
```

## Notes and recommendations

- For demo convenience the repo enables key-based auth in the Bicep templates; for production prefer `disableLocalAuth: true` and use managed identity (AAD).
- If you plan to run or debug services locally, ensure Visual Studio 2022 or VS Code plus .NET 9 SDK are installed.
