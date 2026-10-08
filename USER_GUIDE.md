# Community Library - User Guide

## What is Community Library?

Community Library is a web application that allows users to browse, borrow, and return books from a digital library catalog. It is built for students, faculty, and community members who want to manage their book loans online without needing to visit a physical library desk.

## Getting Started

### Creating an Account

To use the library you need to create an account first. Go to the Register page and you will need to provide:

- Email - your email address, this will be your username
- Password - must be at least 6 characters
- Confirm Password - type the same password again
- Security Word - a word that will be used to verify your identity if you forget your password, letters only, no numbers or special characters

You can also register using your Google account by clicking the "Continue with Google" button, which skips the form and creates your account automatically using your Google email.

### Logging In

Go to the Login page and enter the email and password you used to register. If you registered with Google, click the Google button to log in with your Google account instead.

If you forgot your password, click the "Forgot your password?" link. You will need to enter your email and your security word to verify your identity, then you can set a new password.

### Dashboard

After logging in, click on your account name in the navigation bar to access the Dashboard page. From here you can:

- Borrowed Books - view your current book loans by clicking "View Borrowed Books"
- Admin Panel - if you have an admin role, you will see an additional card to access the admin panel (regular users will not see this)

### Home Page

The home page is the landing page of the application. It gives a general overview of the library and is accessible to everyone, logged in or not.

### Catalog

The Catalog page shows all the books available in the library. You can:

- Search for books by title or author using the search bar
- Filter books by category using the sidebar on the left
- Filter by availability using the checkboxes
- Sort books by title, author, or availability

Each book card shows the cover image, title, author, category, and how many copies are available. If you are logged in and a book has available copies, you can click the Borrow button to borrow it. If you are not logged in, the button will redirect you to the login page.

### Borrowing a Book

To borrow a book, go to the Catalog page, find the book you want, and click Borrow. The system will:

- Create a loan record linked to your account
- Set a due date of 14 days from now
- Decrease the available copies by one

You cannot borrow the same book twice at the same time.

### Returning a Book

To return a book, go to your Dashboard and click **View Borrowed Books**. You will see a list of all your active loans with the due date and status (On Time, Due Soon, or Overdue). Click the Return button next to the book you want to return. The system will mark the loan as returned and the available copies will go back up by one.

## Admin Guide

Admin users have access to the Admin Panel from their dashboard. The admin panel allows you to manage all books in the library.

### Viewing Books

The admin panel shows a table (desktop) or card list (mobile) of all books with their cover, title, author, category, available copies, and published date.

### Adding a Book

Click the Add Book button at the top. A form will pop up where you fill in the title, author, category, total copies, available copies, published date, cover image URL, and description. Click Add to save the book to the database.

### Editing a Book

Click the Edit button next to any book in the list. The same form will pop up with the book's current information already filled in. Make your changes and click Save.

### Deleting a Book

Click the Delete button next to any book. A confirmation popup will ask if you are sure. Click Delete to confirm or Cancel to go back.
