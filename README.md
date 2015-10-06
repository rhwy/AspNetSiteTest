# Web Site Testing Performances

This web site is a combination of small libs and simple code in order to test the most efficient and simple way to have efficient pages with ASP.NET today.


## About

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

For the most hypothesis to test the routing pattern will be

		/{web_framework}/[async/sync]/{data_access}/sync/async

Where:

* web_framework = nancy | webapi
* data_access = rawsql | dapper | simpledata

and for each one you can choose the async or sync version.

There is also an `empty` route for each web framework to test just the time the handler takes to return an HTTP OK.

## Why

Most of the times actually I use to use simple Azure web sites and Sql Azure for my business and non-business development and production in order to avoid as much
as possible friction with production environments and keep things as simple as possible. And it works pretty well for most scenarios without having complicated infrastructure,
when you need more infrastructure, you may have other problems than hosting your website ;-).

But recently I started to have relatively bad response times when my concurrent connections raise up on the web sites with randomly very bad access times. 

So, in order to test things properly, I setup this simple site to test one very basic thing at a time : access a page, async and sync, very simple sql, etc...

My initial target was to have something around 50 concurent users with a mean response time under 200ms. Even if it sounds reasonable, it looks like that's not so easy on azure...


## Install

* restore packages
* Create Sql stuff needed with the `WebTestData.sql` script
* update your connectionString into the web.config
* run it!
* 
Or test it on your site : 

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)


## Test

* Test the api directly with a rest client or whatever to check that site is working (I use to use Postman chrome app which I recommend)
* I included a windows build copy of Apache Benchmark (ab.exe) in this repo
* I included a sample script to test load charge on the site with ab:
	* testload-empty.bat 100 20
	* where 100 is the number of requests to do and 20 the number of concurent request
	* if you deploy the site, change the WEB_SITE parameter of the script
		* SET WEB_SITE=http://localhost:27334/

## Thoughts ?

Discuss on the issues of this repo or PR something.

Feel free to improve and share your results! 

Ping me on twitter [@rhwy](http://twitter.com/rhwy) for any questions
