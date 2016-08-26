Feature: AddToCart

Scenario: Simple add to cart test
	Given I open www.ebay.com page
	And I select first item in search dropdown list
	And I click search button in the header
	And I select first link in categories list
	And I select 'Купить сейчас' checkbox in items container
	And I click '1' item in items container
	When I click Add to cart button
	And I navigate to the cart
	Then the cart sould be contain '1' item
