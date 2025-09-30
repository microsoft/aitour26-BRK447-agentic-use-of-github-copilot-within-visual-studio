# BRK447: Agentic use of GitHub Copilot within Visual Studio

[![Microsoft Azure AI Foundry Discord](https://dcbadge.limes.pink/api/server/Pwpvf3TWaw)](https://discord.gg/Pwpvf3TWaw)
[![Azure AI Foundry Developer Forum](https://img.shields.io/badge/GitHub-Azure_AI_Foundry_Developer_Forum-blue?style=for-the-badge&logo=github&color=adff2f&logoColor=fff)](https://aka.ms/foundry/forum)

This folder contains source and quick-reference material for the BRK-447 session: "Real-World AI Development with Visual Studio and GitHub Copilot." The content here is intended to be used during demos, labs, and for session handouts.

## Session Description

BRK-447 demonstrates how to use GitHub Copilot inside Visual Studio to accelerate development, augment Copilot with MCP servers for documentation-aware suggestions, and employ Copilot Agents to automate issue-driven code changes and UI updates. The session mixes short live demos with recorded segments for longer or fragile flows.

## 🧠 Learning Outcomes

- Use GitHub Copilot effectively inside Visual Studio to accelerate development and scaffolding.
- Leverage MCP servers to augment Copilot with external documentation (for example, Microsoft Learn) to produce context-aware suggestions.
- Use Copilot Agents to automate issue-driven code changes, run unit-test driven flows, and propose UI updates from images.

## 💻 Technologies Used

- `Visual Studio 2022`
- `GitHub Copilot` extension and Copilot Agents
- `Azure AI` services (optional for live demos)
- `MCP (Model Context Protocol)` servers for documentation and tooling integration

## 🔗 Session Resources

Check the [Session Delivery Resources folder](./session-delivery-resources/) for the whole set of materials.

| Resource | Path |
|---|---:|
| Presenter Guide (full) | [session-delivery-resources/readme.md](session-delivery-resources/readme.md)
| Slides | [EN-US_BRK447_Tech_FY26.pptx](https://aka.ms/AAxqj50) |
| Full Session Recording | [Recording](https://youtu.be/F984bvbsOpc) |

## Content Owners

<table>
<tr>
    <td align="center"><a href="http://github.com/mikekinsman">
        <img src="https://github.com/elbruno.png" width="100px;" alt="Bruno Capuano"/>
        <br />
        <sub><b> Bruno Capuano</b></sub></a>
        <br />
        <a href="https://github.com/elbruno" title="talk">📢</a>
    </td>

</tr></table>

## Responsible AI

Microsoft is committed to helping our customers use our AI products responsibly, sharing our learnings, and building trust-based partnerships through tools like Transparency Notes and Impact Assessments. Many of these resources can be found at [https://aka.ms/RAI](https://aka.ms/RAI).
Microsoft’s approach to responsible AI is grounded in our AI principles of fairness, reliability and safety, privacy and security, inclusiveness, transparency, and accountability.

Large-scale natural language, image, and speech models - like the ones used in this sample - can potentially behave in ways that are unfair, unreliable, or offensive, in turn causing harms. Please consult the [Azure OpenAI service Transparency note](https://learn.microsoft.com/legal/cognitive-services/openai/transparency-note?tabs=text) to be informed about risks and limitations.

The recommended approach to mitigating these risks is to include a safety system in your architecture that can detect and prevent harmful behavior. [Azure AI Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/overview) provides an independent layer of protection, able to detect harmful user-generated and AI-generated content in applications and services. Azure AI Content Safety includes text and image APIs that allow you to detect material that is harmful. Within Azure AI Foundry portal, the Content Safety service allows you to view, explore and try out sample code for detecting harmful content across different modalities. The following [quickstart documentation](https://learn.microsoft.com/azure/ai-services/content-safety/quickstart-text?tabs=visual-studio%2Clinux&pivots=programming-language-rest) guides you through making requests to the service.

Another aspect to take into account is the overall application performance. With multi-modal and multi-models applications, we consider performance to mean that the system performs as you and your users expect, including not generating harmful outputs. It's important to assess the performance of your overall application using [Performance and Quality and Risk and Safety evaluators](https://learn.microsoft.com/azure/ai-studio/concepts/evaluation-metrics-built-in). You also have the ability to create and evaluate with [custom evaluators](https://learn.microsoft.com/azure/ai-studio/how-to/develop/evaluate-sdk#custom-evaluators).

You can evaluate your AI application in your development environment using the [Azure AI Evaluation SDK](https://microsoft.github.io/promptflow/index.html). Given either a test dataset or a target, your generative AI application generations are quantitatively measured with built-in evaluators or custom evaluators of your choice. To get started with the azure ai evaluation sdk to evaluate your system, you can follow the [quickstart guide](https://learn.microsoft.com/azure/ai-studio/how-to/develop/flow-evaluate-sdk). Once you execute an evaluation run, you can [visualize the results in Azure AI Foundry portal](https://learn.microsoft.com/azure/ai-studio/how-to/evaluate-flow-results).
