# INTERVIEW_TODO 1
This is a simple warm-up. 
e.g. 
HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, service.Employees); 

## Questions
This is to prompt discussion around dependency injection, interfaces and/or persistent singleton objects.
Anti patterns here are lack of interfaces and lack of a view model (assuming the service is a Db service)

# INTERVIEW_TODO 2
This is another simple warm-up. 
Conditional logic, returning different messages to the front end.

At this stage, the application should run and show a grid of users. 
We can check the UI is working and start looking at debugging skills.

# INTERVIEW_TODO 3
This is a test of C# standard library knowledge.
The solution should find the correct item from the list and replace it with the passed in value.

##Questions
Question 1 should lead to a discussion about validating the record was found, throwing an exception vs changing the method signature to return a boolean.
Question 2 introduces unit tests of the service.

# INTERVIEW_TODO 4
This is a test of C# standard library knowledge.
The solution should find the correct item from the list and replace it with the passed in value.

##Questions
Question 1 should lead to a discussion about validating the record was found, throwing an exception vs changing the method signature to return a boolean.
Question 2 introduces unit tests of the service, types of tests etc.

# INTERVIEW_TODO 5
This is a test of lambda functions
The solution should use Select to create a new LeaveApplicationView and return a List.AsQueryable 
There is a unit test that needs to pass for this

##Questions
This should lead to discussing AutoMapper or similar frameworks.

# INTERVIEW_TODO 6
This is a test of adding references to assemblies and basics of Entity Framework.
The solution should add an Required attribute to the model

##Questions
This should lead to discussing validation methods, e.g. a method or class to validate the object.

# INTERVIEW_TODO 7
This is a test of reading the specificatin, implementing the business logic, and writing tests
The solution should ensure that the property is read only, and that the value is returned from a getter or method.
