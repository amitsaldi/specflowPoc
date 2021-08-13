Feature: Product Service
	Check business logic for Product Service APIs

Background: 
Given the url is "https://app.products.int.ap-southeast-2.dev.a-sharedinfra.net/"
#And the access_token is "test"

#| api-supported-versions | 1.0                       |
@getAttributes
Scenario: Validate get All Attributes API
Given I perform a GET operation for api/v1/attributes
Then I should have the response with status code 200
And the header should contain
| headerName             | headerValue               |
| Content-Type           | application/json; charset |
| Server                 | Kestrel                   |


@addOptionAttributes
Scenario Outline: Validate post for adding attributes to an option
Given I perform a POST operation for api/v1/options/<optionId>/attributes
Then I should have the response with status code 204
Examples: 
| optionId                             |
| 929fb981-2066-41ac-b2bf-5cd81dd003f0 |