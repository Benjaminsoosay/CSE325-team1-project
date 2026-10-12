# Testing & Quality Assurance Plan

As features are developed, the following checks are performed on each page:

## 1. Register Page
- [ ] User can create an account with email, password, and security word
- [ ] Security word only accepts letters, no numbers or special characters
- [ ] User can register using Google OAuth
- [ ] After registering, user is assigned the Customer role

## 2. Login Page
- [ ] User can log in with email and password
- [ ] User can log in with Google account
- [ ] Forgot password flow verifies email and security word before allowing reset

## 3. Catalog Page
- [ ] All books load from the database with cover image, title, author, and category
- [ ] Search filters books by title or author
- [ ] Category sidebar filters books correctly
- [ ] Borrow button works for logged in users and decreases available copies
- [ ] Not logged in users get redirected to login when clicking borrow

## 4. Dashboard Page
- [ ] Only accessible when logged in, redirects to login otherwise
- [ ] Shows Borrowed Books card for all users
- [ ] Shows Admin Panel card only for users with Admin role

## 5. Borrowed Books Page
- [ ] Only accessible when logged in, redirects to login otherwise
- [ ] Shows all active loans with cover image, title, due date, and status
- [ ] Return button marks the loan as returned and increases available copies
- [ ] PDF download button shows when a book has a PDF attached

## 6. Admin Page
- [ ] Only accessible by Admin role, redirects to dashboard otherwise
- [ ] Book table shows all books with cover, title, author, category, and copies
- [ ] Add Book form creates a new book with image and PDF upload
- [ ] Edit button opens the form with existing book data pre-filled
- [ ] Delete button shows confirmation modal before deleting

## 7. Responsive Design
- [ ] Desktop view shows tables, mobile view shows card layout on Admin and Borrowed Books
- [ ] Navigation hamburger menu works on mobile
- [ ] Footer shows on all pages
