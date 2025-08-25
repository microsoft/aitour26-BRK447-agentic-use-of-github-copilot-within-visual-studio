# Video: [brk447-06-query mcp ms learn.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:45

1. Open the products project and inspect the list of products, DbContext, and DB initializer class. [00:00:01.840]  
2. Identify the current DB initializer pattern and note whether it suits EF Core 9. [00:00:01.840]  
3. Enable GitHub Copilot agent mode and turn on the Microsoft Docs tool. [00:00:23.520]  
4. Compose a prompt asking if the current DB initializer is correct for EF Core 9 and request the agent to search Microsoft Docs. [00:00:23.520]  
5. Respond to the tool permission prompt and grant access for this session. [00:00:57.240]  
6. Wait for the agent to search the docs and return recommendations and reference links. [00:01:24.960]  
7. Review the agent's summary, links, and suggested alternative implementations. [00:01:24.960]  
8. Start a new agent session, select the model to use, and allow the agent to read project files. [00:02:12.360]  
9. Let the agent implement the recommended code changes across Program, DbContext, and initializer classes. [00:02:51.653]  
10. Replace EnsureCreatedAsync with MigrateAsync when using migrations and review the agent's diffs before accepting changes. [00:02:51.653]

Related guides:

- [Full user manual](./brk447-06-query mcp ms learn-en-US-02-userguide.md)
- [User manual with snapshots](./brk447-06-query mcp ms learn-en-US-03-snapshots.md)
