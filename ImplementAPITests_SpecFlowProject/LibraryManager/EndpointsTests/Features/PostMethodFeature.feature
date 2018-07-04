Feature: PostMethodFeature

@validData
Scenario Outline: Add a book
	When Add book <book>
	Then Book <book> must be save 
Examples: 
	| book				 |
	| Book1				 |
	| Book4				 |
	| maxInt			 |
	| withoutDescription |
	| author30Chars		 |
	| title100Chars      |
	
@invalidData
Scenario: Аdd a book with existing id
	When Add book Book3
	When Add book Book3
	Then Must show error for Id '3'

@invalidData
Scenario Outline: Аdd a book with invalid id
	When Add book <book>
	Then Must show Id error 
Examples: 
	| book       |
	| negativeId |
	| Book0      |
	| floatId    |
	| tooBigId   |
	| withoutId  |

@invalidData
Scenario: Аdd a book without author
	When Add book withoutAuthor
	Then Must show required author error 

@invalidData
Scenario: Аdd a book longer author
	When Add book author31Chars
	Then Must show longer author error 

@invalidData
Scenario: Аdd a book without title
	When Add book withoutTitle
	Then Must show required title error 

@invalidData
Scenario: Аdd a book longer title
	When Add book title101Chars
	Then Must show longer title error 
