# The history of UI architecture design approaches: from Code-behind to MVVM.

By Fedor Reznik

## 1. Preface.

### 1.1. The purpose 

&nbsp;&nbsp;&nbsp;&nbsp;The whole purpose of this article is to summarize author's experience with regard to UI development and how it evolved via .Net technologies prism. Thus this point of view is highly opinionated and doesn't pretend to be 100% truth. Neither it is historically correct - in the end the MVC pattern itself is older than .Net! We will try to focus on trade-offs of different approaches and why developers have moved from one to another - trying to reveal the idea(s) behind them.
</br>
&nbsp;&nbsp;&nbsp;&nbsp;To give more examples we will need some kind of "Business/Problem domain" wired through different solutions. The problem is if we select a complex one we will hide the ideas in KLOCs and KLOCs of code not related to the actual topic. If we select a simple one some of our arguments might seem a bit artificial and issues highlighted can look dubious or non-existing at all. Well, we will try to keep the domain as simple as it possible - so prepare your imagination to extend the pros and cons highlighted to more complex areas.

### 1.2. Domain

&nbsp;&nbsp;&nbsp;&nbsp;Let's imagine that we are running an automatic cat feeder business. Right now we are only providing hardware configured feeders - with physical buttons on device. Our engineering team has developed and integrated into device the bluetooth adapter, as well as provided corresponding driver, so the idea is to quickly provide application to control cat feeder remotely. 

### 1.3. First User Story

&nbsp;&nbsp;&nbsp;&nbsp;To quickly conquer the market we as the company must provide the simplest yet use-full application: it should contain only "Feed the cat" button and should provide feedback if the feeding has been successful. Do our UX team came-out with the following design:
<img src="Images/CatFeederAppUX.png"/> 
And the status of feeding should be provided by modal dialog with success/fail message and OK button to close it.

## 2. Back in the days. Code-behind

## 3. Moving to patterns

## 4. MVC

## 5. MVP

## 6. MVVM

## 7. Modern state