# The history of UI architecture design approaches: from code-behind to MVVM.

By Fedor Reznik

## 1. Preface.

&nbsp;&nbsp;&nbsp;&nbsp;The whole purpose of this article is to summarize author's experience with regard to UI development and how it evolved via .Net techonologies prism. We will try to focus on trade-offs of different approaches and why developers have moved from one to another. Thus this point of view is highly opinionated and doesn't pretend to be 100% truth. Neither it is historically correct - in the end the MVC pattern itself is older than .Net! 
</br>
&nbsp;&nbsp;&nbsp;&nbsp;To give more examples on approaches we will need some kind of "Business/Problem domain" wired through different solutions. The problem is if we select a complex one we will hide the ideas in KLOCs and KLOCs of code not related to the actual topic. If we select a simple one some of our arguments might seem a bit artificial and issues highlighted can look dubious or non-existing. Well, we will try to keep the domain as simple as it possible - so prepare your imagination to extend the pros and cons highlighted to more comples areas.

## 2. Domain