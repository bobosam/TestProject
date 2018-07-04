Feature: PutMethodFeature
	
@validData
Scenario Outline: Change a book
	When Add book Book4
	When Change Book4 with <book>
	Then Book <book> must be save 
Examples: 
	| book							|
	| Book4ChangeTitle				|
	| Book4ChangeDescription		|
	| Book4ChangeAuthor				|
	| Book4ChangeTitle100Chars		|
	| Book4ChangeAuthor30Chars		|
	| Book4ChangeWithoutDescription |
	
@invalidData
Scenario Outline: Change a book with invalid id
	When Add book Book4
	When Change Book4 with <book>
	Then Must show Id error 
Examples: 
	| book       |
	| negativeId |
	| Book0      |
	| floatId    |
	| tooBigId   |
	| withoutId  |

@invalidData
Scenario: Change a book without author
	When Add book Book4
	When Change Book4 with Book4ChangeWithoutAuthor
	Then Must show required author error 

@invalidData
Scenario: Change a book longer author
	When Add book Book4
	When Change Book4 with Book4ChangeAuthor31Chars
	Then Must show longer author error 

@invalidData
Scenario: Change a book without title
	When Add book Book4
	When Change Book4 with Book4ChangeWithoutTitle
	Then Must show required title error 

@invalidData
Scenario: Change a book longer title
	When Add book Book4
	When Change Book4 with Book4ChangeTitle101Chars
	Then Must show longer title error 
