Feature: GetMethodFeature
	
@validData
Scenario: Get all books
	When Add book Book1
	When Add book Book2
	When Add book Book3
	When Add book Book4
	Then Books count by title 'Test' must be '2'
	And Books title contain 'Test'
	
@validData
Scenario: Get a book
	When Add book Book1
	When Add book Book2
	When Add book Book3
	When Add book Book4
	Then Get a book with id '3'
	
@invalidData
Scenario: Get a book invalid id
	When Add book Book1
	When Add book Book2
	When Add book Book3
	When Add book Book4
	Then Get a book with invalid id '30'