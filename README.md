# Fibonacci Service Documentation.

## Project Structure or Layers.

Fibonacci Service divided into layers to reduce dependence between them. Dividing into layers also helps to create an abstraction that makes each layer **reusable** and easy to **maintain** and **scale**.

Fibonacci Service divided into 5 layers:
- `Entity Layer.`
- `Repository layer.`
- `UseCase layer.`
- `Presentation layer.`
- `Application (Service) layer.`
- `Cross-Cutting-Concerns layer.`

### Entity Layer.
Entity layer contains all entities, DTOs, standart error codes (enums) that require business and service. Layer path: `/src/Entity`