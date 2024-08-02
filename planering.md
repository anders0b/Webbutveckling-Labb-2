# Planering

## Endpoints

### Customer

| Path                           | Method | Request          | Response                                   | ResponseCodes |
| ------------------------------ | ------ | ---------------- | ------------------------------------------ | ------------- |
| "/api/customers"               | GET    | NONE             | Customer[]                                 | 200           |
| "/api/customers/{id}"          | GET    | int Id           | Customer                                   | 200, 404      |
| "/api/customers/city/{city}"   | GET    | string City      | Customer[]                                 | 200, 404      |
| "/api/customers/email/{email}" | GET    | string Email     | Customer                                   | 200, 404      |
| "/api/customers/"              | POST   | Customer         | "Customer {Customer.FirstName} is created" | 200, 400      |
| "/api/customers/{id}"          | PUT    | int Id, Customer | "Updated {Customer.Id}"                    | 200, 404      |
| "/api/customers/{id}"          | DELETE | int Id           | "Deleted {Customer.Id}"                    | 200, 404      |

### Order

| Path                        | Method | Request                   | Response                                | ResponseCodes |
| --------------------------- | ------ | ------------------------- | --------------------------------------- | ------------- |
| "/api/orders"               | GET    | NONE                      | Order[]                                 | 200           |
| "/api/orders"               | POST   | Order                     | Order is created                        | 200, 400      |
| "/api/orders/{id}"          | GET    | int Id                    | Order                                   | 200, 404      |
| "/api/orders/{id}/{status}" | PUT    | int Id, boolean IsShipped | "{Order.Id} is now shipped/not shipped" | 200, 404      |
| "/api/orders/{id}"          | PUT    | int Id                    | "{Order.Id} is now updated"             | 200, 404      |
| "/api/orders/{id}"          | DELETE | int Id                    | "Deleted {Order.Id}"                    | 200, 404      |

### OrderDetails

| Path                                            | Method | Request                              | Response                               | ResponseCodes |
| ----------------------------------------------- | ------ | ------------------------------------ | -------------------------------------- | ------------- |
| "/api/orderdetails/"                            | GET    | NONE                                 | OrderDetails[]                         | 200           |
| "/api/orderdetails/"                            | POST   | OrderDetail                          | Orderdetail created                    | 200, 400      |
| "/api/orderdetails/{id}"                        | DELETE | int Id                               | Orderdetail deleted                    | 200, 404      |
| "/api/orderdetails/{id}/{productId}/{quantity}" | PUT    | int Id, int product.id, int quantity | {ProductId} has a quantity of {amount} | 200, 404      |

### Product

| Path                             | Method | Request                | Response                                               | ResponseCodes |
| -------------------------------- | ------ | ---------------------- | ------------------------------------------------------ | ------------- |
| "api/products"                   | GET    | NONE                   | Product[]                                              | 200           |
| "api/products/{id}"              | GET    | int Id                 | Product                                                | 200, 404      |
| "api/products/{name}"            | GET    | string Name            | Product                                                | 200, 404      |
| "api/products/{id}/{status}"     | PUT    | int Id, boolean Status | "{Product.Id} is now {Status}                          | 200, 404      |
| "api/products/{id}"              | PUT    | int Id, Product        | "{Product.Id} edited"                                  | 200, 404      |
| "api/products/"                  | POST   | Product                | "{Product.Id} created"                                 | 200, 400      |
| "api/products/{id}"              | DELETE | int Id                 | "Deleted {Product.Id}"                                 | 200, 404      |
| "api/products/{id}/{categoryId}" | PUT    | int id, int categoryId | "{Product.Id} is now part of category {Category.Name}" | 200, 400      |
| "api/products/{id}/{categoryId}" | DELETE | int id, int categoryId | "Category removed from {Product.Id}"                   | 200, 400      |

### Category

| Path                   | Method | Request  | Response                | ResponseCodes |
| ---------------------- | ------ | -------- | ----------------------- | ------------- |
| "/api/categories"      | GET    | NONE     | Category[]              | 200           |
| "/api/categories/{id}" | GET    | int Id   | Category                | 200, 404      |
| "/api/categories/"     | POST   | Category | "{Category.Id} created" | 200, 400      |
| "/api/categories/{id}" | DELETE | int Id   | "Deleted {Category.Id}" | 200, 404      |

## Data

### Customer

| Property Name | Data Type          | Description           |
| ------------- | ------------------ | --------------------- |
| Id            | int                | Id for Db             |
| FirstName     | string             | Customer first name   |
| LastName      | string             | Customer last name    |
| Email         | string             | Customer e-mail       |
| Phone         | string             | Customer phone number |
| Address       | string             | Customer address      |
| PostalCode    | int                | Address postal code   |
| City          | string             | Address city          |
| Orders        | ICollection<Order> | List of orders        |

### Product

| Property Name | Data Type                 | Description                   |
| ------------- | ------------------------- | ----------------------------- |
| Id            | int                       | Id for Db                     |
| Name          | string                    | product name                  |
| Description   | string                    | product description           |
| Price         | double                    | product price                 |
| Category      | ProductCategory           | product category              |
| Status        | boolean                   | if product is in stock or not |
| OrderDetails  | ICollection<OrderDetails> | Relation to OrderDetails      |


### Category

| Property Name | Data Type | Description   |
| ------------- | --------- | ------------- |
| Id            | int       | Category Id   |
| Name          | string    | Category name |

### Order

| Property Name | Data Type                 | Description                       |
| ------------- | ------------------------- | --------------------------------- |
| OrderId       | int                       | Order Id in Db                    |
| CustomerId    | int                       | Customer Id                       |
| OrderDate     | Datetime                  | Date when order was placed        |
| IsShipped     | boolean                   | Has the order been shipped or not |
| OrderDetails  | ICollection<OrderDetails> | Relation to OrderDetails          |

### OrderDetails

| Property Name | Data Type | Description |
| ------------- | --------- | ----------- |
| OrderId       | int       | OrderId     |
| ProductId     | int       | ProductId   |
| Quantity      | int       | Quantity    |
