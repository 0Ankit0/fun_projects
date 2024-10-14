# NextjsWithAsp Template

This template is a modification of the ReactWithAsp template to use Next.js instead of React. It provides a starting point for building applications with Next.js on the client side and ASP.NET Core on the server side.

## Getting Started

### Prerequisites

- [Node.js](https://nodejs.org/) (v14 or later)
- [.NET SDK](https://dotnet.microsoft.com/download) (v5.0 or later)

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/0Ankit0/fun_projects.git
   cd NextjsWithAsp
   ```

2. Install client-side dependencies:

   ```sh
   cd projectname.client
   npm install
   ```

3. Restore server-side dependencies:
   ```sh
   cd projectname.Server
   dotnet restore
   ```

### Running the Application

1. Start the ASP.NET Core server:

   ```sh
   dotnet run
   ```

2. In a separate terminal, start the Next.js development server if it doesn't start automatically:
   ```sh
   cd ClientApp
   npm run dev
   ```

### Troubleshooting

If the client does not run correctly, try deleting the `node_modules` folder and reinstalling the packages:

```sh
cd projectname.client
rm -rf node_modules
npm install
```


## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## Acknowledgements

- [Next.js](https://nextjs.org/)
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)

## Creating a New Template

You can use this project to create a new template. Navigate to the project folder and run the following command:

```sh
dotnet new install .
```

This will install the project as a template, allowing you to use it for new projects.
