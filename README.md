# Deploying and Managing .NET Applications with Kubernetes

Welcome to the repository for the "Deploying and Managing .NET Applications with Kubernetes" demo, presented at the Cebu Microsoft Tech Users Group. In this demo, we explore the deployment and management of .NET applications using Azure Kubernetes Service (AKS). This session provides an introduction to Kubernetes and how it can be leveraged to streamline the deployment process for .NET applications.

## Overview
This demo covers:
- An introduction to Kubernetes and AKS
- Setting up a Kubernetes cluster on Azure
- Deploying .NET applications to the Kubernetes cluster
- Managing and scaling .NET applications with Kubernetes

## Prerequisites
Before getting started, ensure you have the following:
- Azure account
- Basic understanding of .NET development
- Familiarity with Docker

## Coverage of the Demo

### 1. Creating Azure Resources

To set up AKS, the following Azure resources are required:

1. **Resource Group**: `rg-demo`
2. **Virtual Network**: `vnet-aks-demo`
3. **Log Analytics Workspace**: `log-aks-demo`

### 2. ASP.NET Core Identity Framework

Instead of using a sample web app that typically displays a homepage, we will utilize ASP.NET Core Identity. This approach allows us to be more productive by implementing authentication and user management features within our .NET application. You can learn more about ASP.NET Core Identity [here](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio)

### 3. Obtaining Free SSL/TLS with Let's Encrypt
If there is still time, we will cover using Let's Encrypt to obtain free SSL/TLS certificates for your application. Additionally, we will use cert-manager to automatically renew the SSL/TLS certificates.