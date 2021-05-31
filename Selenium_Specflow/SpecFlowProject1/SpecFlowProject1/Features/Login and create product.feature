Feature: Login and create product

User logger test and product creation


Scenario: Test1_Login and create product
	Given I open "http://localhost:5000/" url
	When I enter the login and password and click button
	And I click on the button "all products"
	And Now i click on the button "create new"
	And I fill all the fields of the product and click button
	Then Product created