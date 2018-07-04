Feature: Delete a book
	
@validData
Scenario: Delete a book
	When Add book Book1
	When Add book Book2
	When Add book Book3
	When Add book Book4
	Then Delete a book with id '3'
	
@invalidData
Scenario: Delete a book invalid id
	When Add book Book1
	When Add book Book2
	When Add book Book3
	When Add book Book4
	Then Delete a book with invalid id '30'