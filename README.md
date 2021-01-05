# Blind-LowVision-as91896 - 2.7
Blind &amp; Low Vision fundraising landing page + database -- as91896 - 2.7<br/>
***Coded by <a href="https://github.com/bradley-kyan" title="bradley-kyan Github">Kyan Bradley</a> of [Avondale College](https://www.avcol.school.nz/)***

> ***Note*** - *Connection strings for the azure database used during development are inactive, thus the project will not have proper functionality in current state.*

## Overview ##
This project is part of a solo assesment for NCEA LVL 2 soley created by Kyan Bradley of Avondale College. This repository contains the application for as91896 and the MSSQL queries to required properly reproduce the project.
This project is dependent on the BlindLowVision-Web (as91897-2.8 + as91892 - 2.3) repository.
<hr>

### What is contained in this repository ###
This repository contains xamarin.android csharp code and MSSQL queries written in Visual Studio 2019.
## Dependencies and Requirements ##
To reporoduce this project the following are needed:
<ul><li>A PHP compatible web server running PHP 7.3 or later with MSSQL drivers enabled <br><i> See <a href="#info"><b>info </b></a> for further web server details</i>
<li>Reliable internet connetion
<li>MSSQL Server
<li>Visual Studio 2019
<li><a href="https://visualstudio.microsoft.com/xamarin/">Xamarin</a> package for Visual Studio
  <li>Windows HyperV enabled<br><i>See <a href="#info"><b>info</b></a> for details on how to enable HyperV</i>
<li><a href="https://github.com/bradley-kyan/BlindLowVision-Web">BlindLowVision-Web</a> repository</ul>

*It must be noted that the php scripts connection strings for the MSSQL database in this repository will need to be changed to your database*

## Info ##
To set up the web server I personally used Microsoft IIS due to its great intergration into the Windows OS. XAMPP can be used as well, but i ran into difficulties regarding setting up the MSSQL drivers necessary to run the php scripts.<br>
[Microsoft Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx) made installing the required dependencies easy in comparison to other methods.
##### HyperV on Windows 10 Home Edition: [Link](https://www.itechtics.com/enable-hyper-v-windows-10-home/) #####
##### HyperV on Windows 10 Pro/Enterprise: [Link](https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v) #####

### Special thanks to: ###
 [Redth](https://github.com/Redth) - ZXing Xamarin [link](https://github.com/Redth/ZXing.Net.Mobile)<br/><br/>
 
 Mr Vijay Prasad - Teacher at Avondale College<br>
