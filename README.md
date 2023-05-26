# C# Boss Az Console App

This app contains two sides guest and register. Register contains two side : Admin and User. Both you can login and sign up with smtp connection.
User side contain two part : Worker , Employer. Worker can request a vacancy and search vacancies with category filter. Both Admin and User can
see the Profile and have their own notifications depends on occasion. Employer can create vacancy and request it to Admin, and see vacancies.
Admin panel have apply vacancies with first 8 char of id. When applied the sms send to Employer via notification to notifications. 

Technical Details:

1. Interfaces used with implement process both built in and user define interface.
2. Static Functions class for solid code and a lot of classes for OOP 
3. Acsess Modifiers for all purposes
4. SMTP connection for sending mail with thread for not stopping all processes
5. Enum for categories class
6. Inheritance from user to employer and worker class
7. Encapsulation and Properties for safe variables
8. Clean Code and Solid Code
9. Namespaces in different folders
10. Json Handling for reading and saveing data to json file
11. Comments in unique occasions.
12. Generic type where, when and lot of keyword like these
13. Static class and using static class from different namespaces.
14. Exception Handling as i can do
15. Partial static class function class that different filename for admin, user, worker, employer names but in one function
16. Menu's and interface
17. Const field and nullable occasions
18. Idispose for saving datas to files
