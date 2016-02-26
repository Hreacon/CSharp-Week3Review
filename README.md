# Hair Salon

#### Hair Salon Management, Feb 26th, 2016

#### By Nicholas Jensen-Hay

## Description

Lets a hair salon manage stylists with clients attached to stylists. The ability to find a walk in customer by typing in their name links to the stylist they belong to.

## Setup/Installation Requirements

Please see detailed instructions provided by epicodus here
https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c

### Database Setup

create database hair_salon
create table stylists (id int identity(1,1), name varchar(255))
create table clients (id int identity(1,1), name varchar(255), stylist_id int)

## Support and contact details

Contact Nicholas Jensen-Hay through Github at http://github.com/hreacon/

## Technologies Used

C#, Nancy, Razor

### License

Copyright (c) 2016 Nicholas Jensen-Hay

MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
