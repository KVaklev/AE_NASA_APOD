# AE_NASA_APOD

_Welcome to NASA Astronomy Picture of the Day (APOD), an innovative web application crafted to ignite your fascination with the universe. This multifaceted platform not only delivers breathtaking astronomical images but also serves as a comprehensive resource for detailed information about asteroids._

## Project Description

**Built using the MVC architecture and powered by ASP.NET Core, this project harnesses the NASA REST API (https://api.nasa.gov) to provide a seamless experience. Users can explore the mysteries of the universe, access data about asteroids, and conveniently export information in .xlsx format. Additionally, the website offers the unique feature of browsing the Astronomy Picture of the Day, enabling users to journey through past celestial wonders.

With a commitment to both scientific exploration and user-friendly functionality, APOD is your gateway to the wonders of the cosmos and the world of asteroids, all in one interactive platform."!

## Features

1. The user **seamlessly browses** through the application.

2. Users can gain **access to the NASA API** via the link provided on the homepage.

3. Home page headers for quick access:

- **Home** - serves as the primary entry point to the application.

- **Asteroids** - The 'Asteroids' header brings users to a page where comprehensive information about asteroids is presented in a structured table format. This view incorporates pagination, enabling users to easily navigate forward and backward through the results. Additionally, a link is available for users to access NASA's website for more in-depth information about a particular asteroid. Finally, an essential feature allows users to export all the data in convenient .xlsx format.

- **APOD Gallery** - Another core feature of the application is 'APOD' (Astronomy Picture of the Day), which presents users with the daily celestial image, accompanied by detailed information including the title, date of publication, URL, and HDURL for high-definition images. This feature is versatile, accommodating both images and videos. In the case of a video, users can seamlessly open and view it within the application.

Furthermore, the application incorporates a search functionality, allowing users to explore past images or videos by specifying their respective publishing dates."

- **About** - In the 'About' section, a brief expression of gratitude from the creator is presented.

- **Developer API** - The 'Developer API' directs users to the Swagger resources.The implementation is simple and is introduced for potential future scalability and extensibility purposes.

## Technologies Used

Front-end: HTML, CSS
Back-end: ASP.NET Core, ASP.NET MVC
IDE: Visual Studio 2022
REST API: ASP.NET Core Web API
Documentation: Swagger

## How to Set Up and Run the Project Locally - follow these steps:

1. Clone the GitLab Repository
2. Install Dependencies and Packages
4. Build and Run the Project - use the appropriate commands to build and run the project.
5. Access the Application - once the project is running locally, you can access the application by opening a web browser and entering the appropriate URL.

## Project Hierarchy and Entity Descriptions

| Layer 	  | Class Libraries  | Description                                                                                                |
|-----------------|------------------|------------------------------------------------------------------------------------------------------------|
| 1. Business     | Dto              | Contains Data Transfer Objects used to transfer data between different layers of the application.          |
|       	  | QueryParameters  | Provides mapping functionality to map objects between different layers or models.                          |                                                                                |                                                                    
|       	  | Mapper           | Defines query parameters for filtering, sorting, and pagination in data retrieval operations.              |
|       	  | Services         | Implements business logic and handles the interaction between the presentation layer and data access layer.|
|       	  |                  |                                                                                                            |
|      		  |                  |                                                                                                            |
|                 |                  |                                                                                                            |
| 2. DataAccess   | Models	     | Contains data models representing the entities stored in the database - APOD, Asteroid                     |
|		  | Repositories     | Implements the repository pattern to encapsulate data access logic for each model.                         |
|		  |	-Contracts   | - Defines interfaces for the repositories, specifying the available operations.                            |
|		  |	-Helpers     | - Represents the connection with NASA API resources.                                                       |
|		  |	-Models      | - Methods implementation for the main features such as get picture of the day, GetAPODByDate               |
|                 |                  |                                                                                                            |
| 3. Presentation |wwwroot	     | Stores static files such as CSS and image files used by the presentation layer.                            |     
|		  |Controllers       | Handles requests from the client-side and coordinates the flow of data between the layers.                 |
|                 |     -Api         | - Contains controllers that implement the RESTful API endpoints for the application.                       |
|                 |     -MVC         | - Contains controllers that handle server-side rendering of views.                                         |
|		  |Views             | Contains the views responsible for rendering the user interface and presenting data to the end-user.       |
|		  |Helpers           | Provides helper classes or methods that assist in rendering views or performing other related tasks.       |

#### Home Page

![N|Solid](https://i.postimg.cc/0N1wwwFp/HomePage.png)

### Asteroids Table

![N|Solid](https://i.postimg.cc/QMDFtrKm/Asteroids-Details.png)

### Asteroid Data in XLSX format

![N|Solid](https://i.postimg.cc/cLRJP5kn/Asteroids-Data-XLSX.png)

### Astronomy Picture Of The Day (APOD)

![N|Solid](https://i.postimg.cc/2jLL2TY4/Astronomy-Picture-Of-The-Day.png)

### APOD for Past Period 

![N|Solid](https://i.postimg.cc/FHNfF4LZ/APODPast-Date.png)

## Credits

This project was created by Kristian Vaklev:

| Contacts | Email |
| ------   | ----- |
| Kristian Vaklev | kristian.vaklev@yahoo.com |

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for detail


