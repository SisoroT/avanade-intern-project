# Intern Project

This project is a website that **allows users to find the average gas price in a specific location in the U.S.** and compare the gas prices between different states.<br>

**Azure Cloud** services were used to **host and connect everything together**.<br>

The **back-end server hosting** was done in **python** using the **Flask** framework.
**Azure Functions** coded in C# were the meat of the **back-end** by using **http and timer triggers** to **gather information through different APIs and webscraping**.<br>

The **front-end** was put together using a mix of **javascript, css, and html templates with the help of Jinja**.

<p align="center">
  <img src="./assets/homepage.png"/>
</p>

-   [Meet The Interns](#about-us)
-   [Using the Website](#using-the-website)
    -   [Search by Zipcode](#searching-by-zipcode)
    -   [Searching by Map](#searching-by-map)
    -   [Prices by State](#prices-by-state)
-   [Contact Page](#contact-page)
-   [Want to Learn More?](#learn-more)

# About Us

This project was put together by a team of 4 interns.
**Kaylie Naylor and Sumayyah Islam** were the **front-end developers** for this project while **Braedon Lindsey and myself (Ryan Taylor)** were the **back-end developers** for this project.
The **about us** page provides a bit of **background information about each of us**.

<p align="center">
  <img src="./assets/about-us.png"/>
</p>

# Using the Website

There are **multiple ways to get information** through the website.
Users can search by **zipcode** or **through a map**.
We also provide a **page with all the average state prices** in one place.

## Searching by Zipcode

The **zipcode** page allows users to input any **U.S.** zipcode and receive the **average gas prices** for:

-   the **given zipcode**
-   the **state that zipcode is in**
-   the entire **U.S.**

The user is also provided with the state and national average gas prices based on the data in our azure SQL database which updates prices automatically every Sunday at midnight.

https://user-images.githubusercontent.com/65800865/182936857-93442f45-97e1-4d83-974d-d3bbba21cbf5.mp4

## Searching by Map

The **map** page allows users to click anywhere within the U.S. and **drop a pin** to get information.
Users can **pan and zoom** to get to the precise location desired. The information mirrors that provided by the zipcode page.

https://user-images.githubusercontent.com/65800865/182935891-48a47cc2-3598-4344-9ec4-af041ae2c7fd.mp4

## Prices by State

The **state prices** page allows users to see **today's average gas prices** for **every U.S. state plus Washington DC**.
Users can **sort** the page in ascending or descending order either **alphabetically** or **by price** by clicking the label at the top of a column.

https://user-images.githubusercontent.com/65800865/182937123-0e99c2ae-6239-4626-9b96-300f73767b4e.mp4

# Contact Page

The **contact us** page allows users to input their name and email to **sign up to an email list**.
Users can also **submit questions, suggestions, or concerns**.
This information is **submitted to our azure SQL database**.

<p align="center">
  <img src="./assets/contact.png"/>
</p>

# Learn More

Still Interested? Want to learn more about the specifics? [Watch us present our project to our internship cohort!](https://youtu.be/7AOjZtoHZ2M)
