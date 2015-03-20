# aspnet-identity-cache
Sample application for my [Stack Overflow](http://stackoverflow.com/questions/29170366/aspnet-identity-caching-with-dependency-injection) question, showing the caching issue with ASPNET identity and Ninject.  `WebApplication1` is working without DI.  `WebApplication2` shows the caching issue with Ninject.

## Repro Steps

1. Clone the repository.
2. Run the migrations in `WebApplication1` and `WebApplication2` projects to create databases and seed them.
3. Run `WebApplication1`.
4. Change the `foo` user's name and refresh the web site.  The new name should be shown.
5. Run `WebApplication2`.
6. Change the `bar` user's name and refresh the web site.  The new name will not be shown.
7. You can loign to `WebApplication2`.  The `bar` user's password is `password`.  The password can be changed in the site.
