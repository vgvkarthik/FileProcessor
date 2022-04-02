Enviornment Used: VisualStudio Community Edition, Windows11
Time Taken
1. boilerplating the structure - 1 hr
2. Writing core business logic - 2 hrs
3. Testing and Fixing issues - 2 hrs

Assumptions made:
Each line in the file is considered as a record. each data will be seperated by space with few exceptions.
Strucrure of data will be uniform across all records and the provided input file needs some corrections. 
For example airport codes should be 3 chars and will be seperated by space.

Approach Used:
1. Eachline in the file is read using filereader
2. for processing each record multiple rules were creating keeping seperation of concern in mind. 
For Example LineNumberrule process LineNumbers. FlightNumberrule process and retract flightnumber.
3.An orchestration layer named processor is created where all rule execution were orchestrated.
4. All the rules were executed in parallel for better performance
5. Factory is created and all the rules were instantiated from factory and is injected in the processor