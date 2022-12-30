# Smart Microservices
A set of services to communicate with third-party APIs as well as internall business logics.
# Features
Basically, this service contains 4 microservices which covers two features, Google’s Distance API and ISSN code checker.
1. A web service that contains three endpoints:
  - Get distance from google API.
  - Check ISSN code validity.
  - Get list of these smart microservicecs from some sort of persistent storage, in this cas MSSQL Server.
# Specification
The back-end stack is ASP.NET Core 6.
Services are communicating via gRPC.
For managing the containers, we are using docker and Kubernetes.
The application has been written by the TDD approach.
# Installation Guide
1. First of all you can build the docker image and push it or you can pull current version.
- To build and push do the following: 
  - Please make sure you build and push the latest changes to docker. for doing that please follow below steps: 
  - Docker build -f "path to docker file" -t microservicesmartapi "c:\path\to\directory of project"
  - Then tag your build: docker image tag microservicesmartapi:latest [docker hub]:[your tag]
  - Then push it: docker push ~/microservicesmartapi:[your tag]
- To pull and run the current version simply use this command: 
  - Docker run -d –-name microservicesmartapi -p 8080:80 abbasrezaey1/microservicesmartapi
  - Docker run -d –-name microservicesmartservicesrequestreceiver -p 7036:5036 abbasrezaey1/microservicesmartservicesrequestreceiver
  - Docker run -d –-name microservicesmartservicesgoogledistance -p 7094:5094 abbasrezaey1/microservicesmartservicesgoogledistance
  - Docker run -d –-name microservicesmartservicesissnchecker -p 7290:5290 abbasrezaey1/microservicesmartservicesissnchecker
2. Deploy the container object to some sort of cloud Kubernetes, like Azure
- Go to the Azure portal (AKS) and create a Kubernetes cluster
- Install Azure CLI
  - Once Azure CLI is ready, run “az –version” at a command line. You should see an output. 
- Connect to the Cluster, please install Kubernetes CLI as well.
  - Once it’s installed, run “kubectl version –client” at you command line. You should see output.
- Now that you’ve created an AKS Kubernetes cluster, you need to connect your kubectl client to it. There is one more Azure-specific step to do this:
  - az aks get-credentials --resource-group apress-rg --name AksCluster Merged "AksCluster" as current context in C:\Users\myusername\.kube\config
3. Define Kubernetes Objects (This step has already done).
4. Deploy to the Cluster:
  - kubectl apply -f app.yaml [your address] created
5. Please notice to change the google API keys in appsetting file.
6. After successful installation, open the browser and go to the address of API (https://+:80/swagger/index.html), here you will see two get methods
  - first one is Get Distance 
  - second one is CheckISSNCode
  - you can see all details about the request and response here.
