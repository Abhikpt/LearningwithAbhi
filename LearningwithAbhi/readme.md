
# My Blazor Learning Project
Welcome to my website, a platform I'm developing as part of my learning journey with Blazor. Here’s what you can explore:

## Features
1. **Blazor Learning Journey**
   - This project showcases my hands-on experience with Blazor.

2. **Informative Pages**
   - Navigate through various sections including Blogs, About, Contact, and a Feedback Form.

3. **Interactive Web Tools**
   - Access useful web tools like calculators that I will be creating and integrating.

4. **Engaging Blog Content**
   - Stay tuned for insightful blog posts that I will be writing and sharing in the future.

5. **Web Automation Demo**
   - Visit the demo page for practical examples of web automation using Selenium.

## Getting Started
To get a local copy up and running follow these simple steps.

### Prerequisites
- .NET SDK: Ensure you have the .NET SDK installed on your machine.

### Installation
1. Clone the repo
   ```sh
   git clone https://github.com/your-username/your-repo-name.git





Application Template: Blazor WebAssembly Hosted template
 This template is used to build Blazor applications where the client-side application (Blazor WebAssembly) 
 interacts with the server-side backend (usually via an API or SignalR) for processing and data handling. 
 The Shared project typically contains models, services, or other code that both the Client and Server 
 projects share.



#Client (Blazor WebAssembly):
-This is the Blazor WebAssembly application that runs on the client side, in the user's browser.
-It contains Razor components (.razor files) and static web resources (JavaScript, CSS, etc.).
-It can make HTTP requests to the server (usually through a REST API or SignalR) to fetch or send data.

#Server (ASP.NET Core Server):

-This project is an ASP.NET Core Web API that serves as the backend for the application.
-It hosts the Blazor WebAssembly client, typically via an API that the client interacts with for CRUD operations.
-It may include APIs, controllers, services, and other server-side logic.
-It can also be the location of authentication, authorization, and database interactions.


#Shared:
-This project contains code that is shared between the Client and Server projects, such as data models, DTOs (Data Transfer Objects), and services.
-The goal of the Shared project is to reduce duplication of code that would otherwise need to be present in both the Client and Server projects.
-It ensures consistency between the client and server by centralizing logic or data structures that both projects need to reference.


### Solution Structure:

This solution contains 3 projects:

- Client – Blazor WebAssembly app (UI)
- Server – ASP.NET Core Web API and host
- Shared – Shared models between Client and Server

/LearningwithAbhi
    /Client           -> Blazor WebAssembly (Client-side) 
        - wwwroot/     -> Static files (CSS, JS, etc.)
        - Pages/       -> Razor Pages (UI components)
        - Program.cs   -> Client entry point
    /Server           -> ASP.NET Core Web API (Server-side)
        - Controllers/ -> API Controllers (if any)
        - Pages/       -> Blazor Pages for server-side rendering (optional)
        - Program.cs   -> Server entry point (API hosting)
    /Shared           -> Shared project (Models, DTOs, Services, etc.)
        - Models/      -> Shared models
        - Services/    -> Shared logic or services

## Project steps:

1. Created the Blazor WebAssemly project
```bash
dotnet new blazorwasm -o LearningWithAbhi --hosted
```

2. 



### how added CSS styling:
3. inline elements - Span,
4. block elements - Div
5. Element allignment and posisiotning:    [MainLayout]
        1.  justify-content -> he justify-content property in CSS is used to align and distribute space between items along the main axis of a flex container.
        values:  flex-start, flex-end, center, space-between, 
        example:
        .container {
            display: flex;
            justify-content: flex-start;
        }
6. d-flex ms-auto justify-content-around  added in NavigationLayout screen to make 
        justify-content-around -Distributes items evenly with equal space around them
        ms-auto  - marging + start side (auto, left,right)



## Building and running app:
1. We can use dotnet run to run the application from server root
2. Can use dotnet watch to run the application and reflect cjhanges automatically.



## [Employee CRUD Flow (documentation)](/LearningwithAbhi/Client/Pages/learning/blog-pages/EmplyeeScreenE2E.md)