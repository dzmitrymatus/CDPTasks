Feature: AddToCart

Scenario: Adding one item to cart without login
	Given I open www.ebay.com page
	And I select first item in search dropdown list
	And I click search button in the header
	And I select first link in categories list
	And I select 'Купить сейчас' checkbox in items container
	And I click '1' item in items container
	When I click Add to cart button
	And I navigate to the cart page
	Then the cart sould be contain '1' item

Scenario: Adding two items to cart without login
	Given I open www.ebay.com page
	And I select first item in search dropdown list
	And I click search button in the header
	And I select first link in categories list
	And I select 'Купить сейчас' checkbox in items container
	And I click '1' item in items container
	When I click Add to cart button
	And I click continue shopping button 
	And I click '2' item in items container
	And I click Add to cart button
	And I navigate to the cart page
	Then the cart sould be contain '2' item

Scenario Outline: Adding one item to cart as logined user
	Given I open login page
	And I login in system with login:<login> and password: <password>
	And I navigate to the cart page
	And I clear cart
	And I open home page
	And I select first item in search dropdown list
	And I click search button in the header
	And I select first link in categories list
	And I select 'Купить сейчас' checkbox in items container
	And I click '1' item in items container
	When I click Add to cart button
	And I navigate to the cart page
	Then the cart sould be contain '1' item

	Examples:
    | login					    | password   | 
    | "automation.test@mail.ru" | "502211qw-"|