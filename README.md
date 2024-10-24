# BritInsuranceTestAutomation
# Prerequistes -
Nuget packages Selenium WebDriver, Rest Sharp, NUunit etc.

# How to Run Tests
- Open Test -> Test Explorer
- Select test -> Run Tests

# Project Folder Structure
  - UITests -
    This contains all test classes and Individual NUnit tests for UI. Each class is inheriting BaseTest class.
  - APITests -
    This includes API tests including related private methods.
  - Base -
    BaseTest class contains Setup and TearDown methods along with IWebDriver instance.
  - Helpers -
    DataHelper - Helper methods to generate random string.
    WaitHelpers - Extended methods for Implicit and Explicit Waits.
    We can keep adding multiple helper methods for different classes.
  - Model -
    Classes with data models with properties for each fields.
  - TestData -
    Test data files e.g AddProduct.json instead of hardcode we can retrive it from here.
  - Pages -
    - Page object repository along with methods related to specific page.
