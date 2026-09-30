# Testing & Quality Assurance Plan - Benjamin

As features are developed, I will be responsible for the following checks:

## 1. Book Details Page Checklist
- [ ] Verify title, author, and genre display correctly for all books.
- [ ] Verify the cover image loads, and a placeholder shows if the image is missing.
- [ ] Verify the "Borrow" button is disabled if `IsAvailable` is false.

## 2. Checkout/Reserve Book Checklist
- [ ] Verify clicking "Borrow" opens the Confirmation Modal.
- [ ] Verify the "Due Date" is calculated correctly (14 days from today).
- [ ] Verify clicking "Cancel" closes the modal without changing the book's status.
- [ ] Verify clicking "Confirm" changes the book status to "Checked Out".

## 3. Responsive Design Testing
- [ ] Test on desktop view (buttons should be aligned properly).
- [ ] Test on mobile view (images and text should stack vertically).