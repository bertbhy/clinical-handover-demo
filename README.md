# clinical-handover-demo

<!-- PROJECT HEADER -->
<br />
<div align="center">
  <h3 align="center">Clinical Handover Demo</h3>
  <p align="center">
    A hospital IT project for supporting clinical handovers. Built with .NET Core, React.
  </p>
  <p>
     <a href="https://bert-bei-clinical-handover.azurewebsites.net/">
    <strong>View demo on Azure</strong></a>
  </p>
</div>

<details><summary>Table of Contents</summary>

- [clinical-handover-demo](#clinical-handover-demo)
  - [About the Project](#about-the-project)
    - [Built With](#built-with)
      - [Backend](#backend)
      - [Frontend](#frontend)
      - [Tools](#tools)
  - [Getting Started with Online Demo](#getting-started-with-online-demo)
  - [Backend Design](#backend-design)
    - [Database Design](#database-design)
    - [Service Interface](#service-interface)
    - [Service Implementation](#service-implementation)
    - [Api Controller](#api-controller)
    - [Swagger API Documentation](#swagger-api-documentation)
    - [Xunit Test](#xunit-test)
    - [Mock Data](#mock-data)
  - [Frontend Design](#frontend-design)
    - [Component](#component)
    - [Axios Client](#axios-client)
  - [Deployment](#deployment)
    - [Docker](#docker)
    - [Azure](#azure)
  - [Acknowledgments](#acknowledgments)

</details>

<!-- ABOUT THE PROJECT -->
## About the Project

[![Product Name Screen Shot][product-screenshot]](https://github.com/bertbhy/clinical-handover-demo)

This is a project to enable effective clinical handover in order to safeguard patient safety by ensuring specific care plans can be efficiently conveyed to (i) clinicians at various levels and (ii) across different professional disciplines.

It is one of my biggest achievement at the hospital to accomplish the project objectives:

To accelerate the adoption of ISBAR model for clinical handover:

- Introduction
- Situation
- Background
- Assessment
- Recommendation

To make use of IT strategies to seal the potential loopholes:

- Limited accessibility to working folders
- Information delivery by hard copy
- Lack of effective tool to enhance specialty specific handover

### Built With

#### Backend

[![dotnet][dotnet-url]](https://dotnet.microsoft.com/en-us/apps/aspnet)
[![ef][ef-url]](https://docs.microsoft.com/ef/)
[![sql][sql-url]](https://www.microsoft.com/en-us/sql-server/)
[![cs][cs-url]](https://dotnet.microsoft.com/en-us/languages/csharp)

#### Frontend

[![React][React.js]](https://reactjs.org/)
[![chakra][chakra-url]](https://chakra-ui.com/)
[![ts][ts-url]](https://www.typescriptlang.org/)

#### Tools

[![azure][azure-url]](https://azure.microsoft.com/en-us/get-started/azure-portal)
[![docker][docker-url]](https://www.docker.com/)
[![vscode][vscode-url]](https://code.visualstudio.com/)
[![swagger][swagger-url]](https://swagger.io/)

<!-- GETTING STARTED -->
## Getting Started with Online Demo

- Login
- Select a group
- Select a patient
- Edit handover form
- View handover versions
- Show handovers by date
- Delete handover

## Backend Design

### Database Design

- dbContext.cs
- GetWardPatient.cs
- Handover.cs
- HandoverGroup.cs
- HandoverLog.cs

<details><summary>ER Diagram</summary>

[![er](https://mermaid.ink/img/pako:eNplkVFvgjAQx79Kc88CEzZU3kw0arKJUbdkCS-lPaAJUNMWEwN89xWZ7mH3dv_7_e96vRaY5AgRoFoJmitaJTWxcVied-v9mfTSdbuObI7x54FEJIEUS1nnmhiZwIhul_tV_LU-PtiHdaA5aqZEivof3EnH6Vqy3Z3O8fH7Dl9RaSFrUeckvT0M7_GG9J3jyO7PO8BGUTa2hQlUqCoquF2jHVy2WmCFCYxPyGhTmoHsLUobI0-3mkFkVIMTaC6cGvzdHaKMlvqprrkwUj3FUlKONm3B3C7Dn-VCG9uSyToT-aA3qrRyYcxFR543lN1cmKJJXSYrTwteUGWK6yL0Qj-cUz_AcBbQtyDgLJ0u5pn_Os347GXqU-j7CeB9_sd4oPud-h9uU4mx?type=png)](https://mermaid.live/edit#pako:eNplkVFvgjAQx79Kc88CEzZU3kw0arKJUbdkCS-lPaAJUNMWEwN89xWZ7mH3dv_7_e96vRaY5AgRoFoJmitaJTWxcVied-v9mfTSdbuObI7x54FEJIEUS1nnmhiZwIhul_tV_LU-PtiHdaA5aqZEivof3EnH6Vqy3Z3O8fH7Dl9RaSFrUeckvT0M7_GG9J3jyO7PO8BGUTa2hQlUqCoquF2jHVy2WmCFCYxPyGhTmoHsLUobI0-3mkFkVIMTaC6cGvzdHaKMlvqprrkwUj3FUlKONm3B3C7Dn-VCG9uSyToT-aA3qrRyYcxFR543lN1cmKJJXSYrTwteUGWK6yL0Qj-cUz_AcBbQtyDgLJ0u5pn_Os347GXqU-j7CeB9_sd4oPud-h9uU4mx)

</details>

### Service Interface

- IAccountService.cs
- IHandoverService.cs
- IPmiService.cs

### Service Implementation

- AccountService.cs
- HandoverService.cs
- PmiService.cs

### Api Controller

- AccountController.cs
- HandoverController.cs
- PmiController.cs

### Swagger API Documentation

- [View API Doc on Azure](https://bert-bei-clinical-handover.azurewebsites.net/swagger/)

### Xunit Test

- AccountControllerTest.cs
- HandoverControllerTest.cs
- PmiControllerTest.cs

### Mock Data

- MockData.cs
- MockActiveDirectory.cs

## Frontend Design

### Component

- HandoverForm.tsx
- HandoverHistory.tsx
- DataGridPatient.tsx
- DataGridHandover.tsx

### Axios Client

- axiosService.ts
- typescript-axios

## Deployment

### Docker

- docker-compose

### Azure

- Azure Web App
- Azure SQL Server

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

Here is a list of great libraries that I find helpful and would like to give credit to. Thank you!!

- [axios](https://axios-http.com/ "axios")
- [chakra-ui](https://chakra-ui.com/ "chakra-ui")
- [date-fns](https://github.com/date-fns/date-fns "date-fns")
- [dotenv](https://github.com/motdotla/dotenv "dotenv")
- [dynamic-linq](https://dynamic-linq.net/ "dynamic-linq")
- [jqwidgets-scripts](https://www.jqwidgets.com/ "jqwidgets-scripts")
- [lodash](https://lodash.com/ "lodash")
- [moq](https://moq.github.io/moq4/ "moq")
- [nswag](https://github.com/RicoSuter/NSwag "nswag")
- [react-datepicker](https://github.com/Hacker0x01/react-datepicker "react-datepicker")
- [react-hook-form](https://www.react-hook-form.com/ "react-hook-form")
- [react-icons](https://react-icons.github.io/react-icons/ "react-icons")
- [react-use](https://github.com/streamich/react-use "react-use")
- [rxjs](https://rxjs.dev/ "rxjs")
- [swagger-codegen](https://github.com/swagger-api/swagger-codegen "swagger-codegen")
- [xunit](https://xunit.net/ "xunit")
- [yup](https://github.com/jquense/yup "yup")

<!-- MARKDOWN LINKS & IMAGES -->
[product-screenshot]: images/screenshot.png
[React.js]: https://img.shields.io/badge/React-20232A?style=flat-square&logo=react&logoColor=61DAFB
[dotnet-url]: https://img.shields.io/badge/Asp.Net%20Core-682A7B?style=flat-square&logo=.net&logoColor=F7F7F7
[ef-url]: https://img.shields.io/badge/EF%20Core-682A7B?style=flat-square&logo=.net&logoColor=F7F7F7
[sql-url]: https://img.shields.io/badge/SQL%20Server-F7F7F7?style=flat-square&logo=Microsoft%20SQL%20Server&logoColor=CC2927
[azure-url]: https://img.shields.io/badge/Azure-0078D4?style=flat-square&logo=Microsoft%20Azure&logoColor=F7F7F7
[chakra-url]: https://img.shields.io/badge/Chakra%20UI-319795?style=flat-square&logo=Chakra%20UI&logoColor=white
[ts-url]: https://img.shields.io/badge/TypeScript-3178C6?style=flat-square&logo=TypeScript&logoColor=F7F7F7
[cs-url]: https://img.shields.io/badge/C%20Sharp-239120?style=flat-square&logo=C%20Sharp&logoColor=F7F7F7
[swagger-url]: https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=Swagger&logoColor=173647
[docker-url]: https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=Docker&logoColor=white
[vscode-url]: https://img.shields.io/badge/VS%20Code-F7F7F7?style=flat-square&logo=Visual%20Studio%20Code&logoColor=007ACC