# Video: [brk447-01-Initial Setup.mp4](./REPLACE_WITH_VIDEO_LINK) — 00:03:02

1. Log into Azure with your tenant to target the correct subscription: `az login --tenant <tenant-id>`. [00:00:13.360]  
2. Run the command/script to create the new resource group and wait for it to complete, then capture the CLI JSON output for IDs and keys. [00:00:31.316]  
3. Run the command to show the endpoint and foundry/account name, then copy those displayed values. [00:00:58.409]  
4. Edit the local script to insert the resource group and account/foundry name, then run the script to produce the connection string. [00:00:58.409]  
5. Paste the connection string into the AI Foundry parameter prompt in the dashboard and save it to user secrets. [00:01:37.120]  
6. Start the application and verify functionality such as browsing and semantic search. [00:01:37.120]  
7. To switch resources, open the app host’s user secrets, delete the AI Foundry entry, then run and re-add the updated value. [00:02:18.160]  
8. Open the Azure Portal, navigate to the resource group and the Azure OpenAI/OpenAI resource, verify the GPT-4o-mini and ADI O2 deployments, and copy the endpoint and key values from the portal. [00:02:39.848]

Related guides:

- [Full user manual](./brk447-01-Initial Setup-en-US-02-userguide.md)
- [User manual with snapshots](./brk447-01-Initial Setup-en-US-03-snapshots.md)
