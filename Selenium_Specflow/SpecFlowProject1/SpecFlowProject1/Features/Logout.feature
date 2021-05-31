Feature: Logout
	
	Exit account


Scenario: Test3_Account output
	Given I open the last time "http://localhost:5000/" url
	When I enter the last time the login and password and click button
	And And Now i click on the button "logout"
	Then The login page is opened