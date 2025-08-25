# Video: [brk447-05 add mcp servers.mkv](./REPLACE_WITH_VIDEO_LINK) — 00:02:42

# Empower GitHub Copilot with MCP Servers — User Manual

This manual shows how to add external MCP (Model Connector Provider) servers — specifically GitHub and Microsoft Docs / Microsoft Learn — to GitHub Copilot inside Visual Studio by creating an `mcp.json` file in your solution root. Follow the steps below to configure, authenticate, and verify the new tool sources in Copilot.

---

## Overview
Duration reference: 00:00:02 — 00:02:40

Goal: extend GitHub Copilot’s capabilities by adding MCP servers so Copilot can use additional tools (for example, GitHub tools and Microsoft Docs/Learn tools).

What you will do:
- Inspect the default MCP tools (00:00:16 — 00:00:32)
- Create an `mcp.json` in your solution root (00:00:56 — 00:01:22)
- Add GitHub server entry and authenticate (00:01:22 — 00:01:56)
- Add Microsoft Docs server entry and verify tools appear in Copilot chat (00:01:56 — 00:02:40)

Important: Visual Studio may prompt to use your locally authenticated credentials to connect a configured server. Accepting will allow Copilot to access tools from that server.

---

## Step‑by‑Step Instructions

### 1. Inspect the default MCP tools (00:00:16 — 00:00:32)
1. Open your solution in Visual Studio.
2. In Visual Studio, locate the MCP / Copilot tooling area:
   - Open GitHub Copilot (or the Copilot extension) and review the available "Tools" list.
   - Optionally, open any Visual Studio menu that lists MCP servers to see the current configured servers.
3. Note the default tools available (the video shows only two by default).

Tip: Confirm you see the “local” Copilot tool and any default sources before making changes so you can verify the new sources later.

---

### 2. Choose which servers to add (00:00:32 — 00:00:56)
1. Decide which external servers you want Copilot to use. In the demo:
   - GitHub (to expose GitHub-specific tools)
   - Microsoft Docs / Microsoft Learn (to expose documentation-based tools)
2. Plan to create an `mcp.json` in your solution root to register these servers, following Visual Studio / documentation instructions.

Tip: Use the official MCP documentation entries when available. The example config below shows the structure and placeholders you can use.

Warning: Adding a server does not automatically connect it; Visual Studio will prompt for authentication before allowing Copilot to use that server’s tools.

---

### 3. Create `mcp.json` in the solution root (00:00:56 — 00:01:22)
1. In Visual Studio, open Solution Explorer and select the solution root (top-level node).
2. Right-click → Add → New Item (or Add New File).
3. Name the file exactly: `mcp.json`
4. Save the new file.

Tip: Placing `mcp.json` in the solution root is required for Visual Studio / Copilot to discover it.

---

### 4. Add GitHub server configuration and authenticate (00:01:22 — 00:01:56)
1. Edit `mcp.json` and insert the GitHub server configuration entry.
   - If you have sample configuration from official docs, paste that exact entry.
   - If you need a template, use the example below as a starting point (replace placeholders with real values from the docs or your environment):
     {
       "servers": [
         {
           "id": "github",
           "displayName": "GitHub",
           "type": "github",
           "url": "https://api.github.com",
           "description": "GitHub MCP server"
         }
       ]
     }
2. Save `mcp.json`.
3. Watch for a Visual Studio prompt. It may ask whether to use your locally authenticated credentials to connect the GitHub server.
   - Choose the local authenticated credential (or appropriate account) if you want Copilot to access your GitHub tools.
4. Allow Visual Studio to cache the server entry. Note: the server entry is cached in the solution but not connected until you authenticate.

Warning: Allowing Visual Studio to use your local credentials will expose your GitHub tools to Copilot. Ensure you approve this access knowingly.

Tip: After authenticating, Copilot may show many additional GitHub tools (the demo references ~90+ tools).

---

### 5. Add Microsoft Docs / Microsoft Learn server and verify tools (00:01:56 — 00:02:40)
1. Add a Microsoft Docs / Microsoft Learn server entry to `mcp.json` (merge with any existing entries). Example structure:
     {
       "servers": [
         {
           "id": "github",
           "displayName": "GitHub",
           "type": "github",
           "url": "https://api.github.com",
           "description": "GitHub MCP server"
         },
         {
           "id": "msdocs",
           "displayName": "Microsoft Docs",
           "type": "microsoftDocs",
           "url": "https://learn.microsoft.com",
           "description": "Microsoft Learn / Docs MCP server"
         }
       ]
     }
   - Replace example values with official entries if provided by Microsoft documentation.
2. Save `mcp.json`.
3. If prompted, allow Visual Studio to connect/authenticate to the new server (or confirm that connection will use the cached configuration/local credentials).
4. Open GitHub Copilot chat in Assistant mode inside Visual Studio.
   - Open the Copilot chat window.
   - Ensure you are in Assistant mode (not code-only or other modes).
5. Open the Tools panel inside Copilot chat and verify that:
   - Microsoft Docs tool(s) appear
   - GitHub tool(s) appear
   - Both sources are now available for Copilot to use

Tip: If a tool does not appear immediately, try saving `mcp.json` again, or closing and reopening the Copilot chat pane. Visual Studio sometimes needs a refresh to detect new server entries.

---

## Example Complete `mcp.json` (template)
Use the example below as a starting template. Replace IDs, types, URLs, and descriptions with the official entries from your provider documentation.

{
  "servers": [
    {
      "id": "github",
      "displayName": "GitHub",
      "type": "github",
      "url": "https://api.github.com",
      "description": "GitHub MCP server"
    },
    {
      "id": "msdocs",
      "displayName": "Microsoft Docs",
      "type": "microsoftDocs",
      "url": "https://learn.microsoft.com",
      "description": "Microsoft Learn / Docs MCP server"
    }
  ]
}

Warning: This is a template. Always prefer the exact JSON snippets provided in Visual Studio or in the official MCP documentation.

---

## Tips & Warnings (general)
- Tip: Keep `mcp.json` at the solution root — Copilot/Visual Studio looks there for MCP server configuration.
- Tip: Use official server entries from Microsoft or GitHub documentation when available to avoid misconfiguration.
- Warning: Connecting servers can expose remote tools and data to Copilot. Only connect servers/accounts you trust.
- Warning: Server entries are cached but will not be used until Visual Studio authenticates the connection.
- Tip: If tools do not appear after saving `mcp.json`, try restarting Copilot or Visual Studio to force re-discovery.

---

Timestamps summary:
- Introduction and goal: 00:00:02 — 00:00:16  
- Inspect default MCP tools: 00:00:16 — 00:00:32  
- Choose GitHub and Microsoft Docs servers: 00:00:32 — 00:00:56  
- Create `mcp.json` file: 00:00:56 — 00:01:22  
- Add GitHub config and authenticate: 00:01:22 — 00:01:56  
- Add Microsoft Docs config and verify tools: 00:01:56 — 00:02:40

Follow these steps to extend GitHub Copilot with MCP servers and verify the new tool sources inside the Copilot chat tools panel.