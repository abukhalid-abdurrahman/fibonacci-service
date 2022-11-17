# Fibonacci Service Documentation.

## Service Design.
![Fibonacci-Service drawio](https://user-images.githubusercontent.com/62469844/202471760-a26e388e-edd7-4591-adc9-236c25a99f24.svg)


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
