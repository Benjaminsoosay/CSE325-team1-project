# CSE325 - Team 1 Project

## Repository
**URL:** https://github.com/Benjaminsoosay/CSE325-team1-project

**Trello Board:** https://trello.com/b/hjnMvDXR/cse325-team-1

## Team Members
- Benjamin Soosay (@Benjaminsoosay) - Team Lead
- Daniel Llumiquinga (@danielllumiquinga2) - Developer
- Emmanuel Kingsley Okafor (@eokafor3) - Developer
- E. Okoye (@eokoye2) - Developer

---

## Project Title: Community Library

### Project Overview
Community Library is a Blazor web application designed to help small community libraries, volunteers, and local readers manage and access books more efficiently. Many small community libraries rely on manual tracking, spreadsheets, or paper logs to manage inventory and borrowing. This application provides a centralized, easy-to-use digital catalog where users can browse books, check availability, and borrow items without needing a physical library building or complex software.

The target users include college students, teachers, local residents, families, and senior citizens. Students and teachers benefit from quick access to study materials, while residents and seniors appreciate the convenience of browsing from home. Volunteers who run small libraries gain a simple inventory management tool that reduces workload and improves organization. This app is valuable because it promotes community connection, sustainability, and resource sharing by making books more accessible and reducing reliance on physical locations.

### Project Scope
**What's IN:**
- User registration and authentication (Patrons and Admins).
- Book catalog with title, author, genre, cover image, and availability.
- Searching and filtering books by title, author, or genre.
- Borrowing system with checkout and due dates.
- User dashboard showing borrowed books.
- Admin panel for adding, editing, and deleting books.
- Responsive UI using Blazor and CSS.

**What's OUT:**
- Payment processing (no late fees or book purchases).
- External API integrations (no Google Books or external library databases).
- Native mobile app deployment (web app only).
- AI book recommendations.
- Automated email notifications for overdue books.

### App Features (User Stories)
1. Users can create an account and log in securely.
2. Users can browse a catalog of available books.
3. Users can search for books by title or author and filter by genre.
4. Users can borrow books and view due dates.
5. Users can track their currently borrowed books in a personal dashboard.
6. Admins can add, edit, and delete books from the catalog.
7. Admins can manage inventory and update book availability.

### Technical Considerations
- Data Storage: User profiles, book details (title, author, genre, cover image, availability), and borrowing records.
- User Accounts: Yes, users must log in to borrow books; browsing is allowed without an account.
- External Services: Optional Google OAuth for simplified login.
- Device Compatibility: Responsive CSS ensures functionality on mobile, tablet, and desktop.
- Basic Security: Passwords will be hashed; authentication required for borrowing; authorization ensures only admins can manage inventory; input validation prevents malicious data entry.

### Project Links
- **GitHub Repository:** [https://github.com/Benjaminsoosay/CSE325-team1-project](https://github.com/Benjaminsoosay/CSE325-team1-project)
- **Trello Board:** [https://trello.com/b/hjnMvDXR/cse325-team-1](https://trello.com/b/hjnMvDXR/cse325-team-1)

---

## Week 4 Team Activity: Project Checkpoint

**Participants:** Benjamin Soosay, Daniel Llumiquinga, Emmanuel Kingsley Okafor, E. Okoye.

**Group Activity Summary:** Our team met to review the progress of our Library Management System project. We updated our Trello board to reflect our current tasks and assigned specific work items to each member. We discussed the architecture and task breakdown for the upcoming week.

**Challenges:** Our primary challenge was resolving namespace errors in our Blazor project and ensuring the routing correctly displayed the new pages. We also struggled to find time to coordinate schedules.

**Successes:** Benjamin successfully implemented the "Book Details Page" and the "Checkout/Reserve Book" modal, including a working "Borrow" button. We also created a Testing & Quality Assurance plan to guide our future testing phases.

**Insights:** We learned the importance of proper file organization in Blazor (keeping components inside the Components/Pages folder) and ensuring namespaces match the project name to avoid compilation errors.

**New Group Leader:** Daniel Llumiquinga was selected as the group leader for the next meeting.