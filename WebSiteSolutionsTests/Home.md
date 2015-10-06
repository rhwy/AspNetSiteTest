# Testing Asp.Net Solutions for performance

## Problem

When hosting applications on Azure web apps it is not 
always easy to see what works best and what 
should be _good numbers_ in terms of performance.

This solution as the purpose of testing in a very simple
way different combination of hypothesis.

* Web Frameworks
    * Web Api 2
    * Nancy
* Data Access
    * Raw Sql commands
    * Simple.Data
    * Dapper

As this test focuses on simplicity and performance, things like Entity where
not included on purpose. That doesn't mean they're not valuable, just not suitable
for clean and simple things (but you're free to contribute btw).

