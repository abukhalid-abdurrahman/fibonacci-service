# Fibonacci Service Documentation.

## Service Design.
![Fibonacci-Service drawio](https://user-images.githubusercontent.com/62469844/202471760-a26e388e-edd7-4591-adc9-236c25a99f24.svg)

The system designed shows how does Fibonacci Service should work. The first step is to receive a request from a client, and check if client wants to get data from cache. Otherwise service would start a new task with specified timeout. That async task would generate a result, and write it to temporary memory. After task execution or it timeout, service would save results into memory cache db, and make a response to client.

But that task implementation is not enough, there a lot of different ways to done it. For example, we can generate a subsequence from sequence of Fibonacci numbers in separated background host/worker. And after it execution we can notify client using http request to a client callback, or use some of message brokers.

## Project Structure or Layers.

Fibonacci Service divided into layers to reduce dependence between them. Dividing into layers also helps to create an abstraction that makes each layer **reusable** and easy to **maintain** and **scale**.

Fibonacci Service divided into 5 layers:
- `Entity layer.`
- `Repository layer.`
- `UseCase layer.`
- `Presentation layer.`
- `Application (Service) layer.`
- `Cross-Cutting-Concerns layer.`

### Entity Layer.
Entity layer contains all entities, DTOs, standart error codes (enums) that require business and service. Layer path: `/src/Entity`

### Repository Layer.
Repository layer is created for storing logic that calls or fetch some data from another resource. In Fibonacci Service **Repository** layer stores a logic for communicating with cache-database. Abstraction layer path: `/src/Repository.Abstraction`. Implementation layer path: `/src/Repository.Implementation`.

### UseCase Layer.
UseCase layer contains a business logic.
Abstraction layer path: `/src/UseCase.Abstraction`. Implementation layer path: `/src/UseCase.Implementation`.

### Presentation Layer.
Presentation layer stores all things that providing communication with clients. It can be some message broker listener, some background hosts etc. Layer path: `/src/Presentation`

### Application Layer.
Application layer is a web api or a service that launchs on a web server with an ip address and port. Clients will communicate with Fibonacci Service from that layer. Layer path: `/src/Api`

### Cross-Cutting-Concerns Layer.
Cross-Cutting-Concerns layer stores logging tools, exceptions or something that we can use in all layers. Layer path: `/src/CrossCuttingConcerns`

# Tests.

## Test naming in Fibonacci-Service.
The most popular template is `[Class Name]_[Method Name]_[Scenario Brief Description]_Scenario` For example we can got *Base64Util_Base64Encode_ShouldEncodeStringToBase64_Scenario*.