
How to run this solution to get the desiered output?.
==========================================================

Run the Tests in TransactionProcessorTests and that will dump the output files in the following folder and validate with expected output for 
three OMS formats

\\WellsFargo.Services.Tests\\bin\\debug\net6.0\Working




Things still to do:
===============================================================
1. Most of the services implement interfaces and ideally I would wire up IoC container to provide dependencies to them, 
	for that reason i have used glues (new) to provide concreate dependencies
2. I will make the portfolio.csv & securities.csv as the part of the services, rather than keeping them in the test project. 
   The reason is that is the metadata/reference data needed by the services to build the final dataset for export should be part of the services/repository.
3. I could have added a console app, but i believe the above E2E should suffice.
4. There is still scope to add unit tests to more service components
5. I would prefer to work with byte[] rather than passing down the file path, that will make the services more flexible for the type of input/client
