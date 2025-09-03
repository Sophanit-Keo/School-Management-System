# EduPortal - School Management System

A comprehensive web-based school management system built with HTML, CSS, and JavaScript.

## Features

### Role-Based Dashboards
- **Admin Dashboard**: User management, class administration, reports, and system oversight
- **Teacher Dashboard**: Class schedules, attendance tracking, exam management, and student reports
- **Student Dashboard**: Personal schedule, assignments, grades, and library access
- **Parent Dashboard**: Child progress tracking, attendance monitoring, fee payments, and teacher communication

### Core Modules
- **User Management**: Complete CRUD operations for all user types
- **Class Administration**: Class creation, enrollment management, and scheduling
- **Attendance System**: Real-time attendance tracking and reporting
- **Grade Management**: Assignment tracking, exam management, and progress reports
- **Fee Management**: Payment tracking, invoice generation, and financial reports
- **Communication**: Messaging system, announcements, and notifications
- **Scheduling**: Master calendar, event management, and timetable creation

## Technology Stack

- **Frontend**: HTML5, CSS3, JavaScript (ES6+)
- **Charts**: Chart.js for data visualization
- **Design**: Custom CSS with design system
- **Storage**: Local storage and JSON files (mock data)

## Project Structure

```
school-management-system/
├── index.html                     # Login page
├── admin/                         # Admin dashboard
├── teacher/                       # Teacher dashboard
├── student/                       # Student dashboard
├── parent/                        # Parent dashboard
├── communication/                 # Messaging system
├── scheduling/                    # Calendar and scheduling
├── shared/                        # Shared components and utilities
├── data/                         # Mock data files
└── vendor/                       # Third-party libraries
```

## Getting Started

1. Clone or download the project
2. Open `index.html` in your browser
3. Use the demo credentials to login:
   - Admin: admin@school.edu / admin123
   - Teacher: teacher@school.edu / teacher123
   - Student: student@school.edu / student123
   - Parent: parent@school.edu / parent123

## Features Implemented

### Authentication System
- Role-based login with demo accounts
- Session management
- Protected routes

### Admin Features
- User management (CRUD operations)
- Class administration
- System analytics and reports
- Fee management oversight

### Teacher Features
- Personal dashboard with working hours tracking
- Class schedule management
- Student attendance tracking
- Exam and assignment management
- Progress reporting

### Student Features
- Personal academic dashboard
- Schedule and timetable view
- Assignment submissions
- Grade tracking
- Library access

### Parent Features
- Child progress monitoring
- Attendance tracking
- Fee payment system
- Teacher communication

### Communication System
- Inbox for all user types
- Message composition
- Announcements
- Role-based message filtering

## Design System

The application uses a comprehensive design system with:
- 8px spacing scale
- Consistent color palette with multiple variants
- Responsive typography using Inter font
- Component-based architecture
- Mobile-responsive design

## Browser Compatibility

- Modern browsers (Chrome, Firefox, Safari, Edge)
- Mobile browsers
- Responsive design for all screen sizes

## Future Enhancements

- Real database integration
- Real-time notifications
- Advanced reporting
- Mobile app development
- API development for third-party integrations