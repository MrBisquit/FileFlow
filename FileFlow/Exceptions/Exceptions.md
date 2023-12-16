# Exceptions
Custom exceptions for FileFlow to make it easier to detect different exceptions and respond to them differently.

Below are the meanings of the exceptions and the different variations (HResult codes) of them.

| Part             | Beginning of HResult code   |
|:----------------:|:---------------------------:|
| Caching          | 12...                       |

## AccessDenied (xx403xx)
When something fails to happen because of an access denied response by something.

### Caching (12403xx)
An access denied exception occurred when trying to do something, the different versions are in this table:
| Location         | HResult Code                | About                         |
|:----------------:|:---------------------------:|:------------------------------|
| Initialisation   | 1240310                     | Caching could not access the configuration file because of an Access Denied exception. |
| Saving           | 1240311                     | Caching could not write to the configuration file because of an Access Denied exception. |