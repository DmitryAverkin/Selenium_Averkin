Feature: Remove product

Removing the created product


Scenario: Test2_Login and remove product
	Given I open again "http://localhost:5000/" url 
	When I enter again the login and password and click button
	And I click again on the button "all products"
	Then Product removal