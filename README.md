# Klaviyo Custom Field Testing - README

## Overview
This project is a simple API for sending custom field data to Klaviyo using its Track API, built on **ASP.NET Core 5**. It allows you to send events like `order_placed`, along with user-specific properties, to Klaviyo for tracking and analytics.

## Key Features
- **Custom Event Tracking**: Sends events (`order_placed`) with fields like `order_id`, `customer_name`, and `order_items`.
- **ASP.NET Core 5**: Developed using **ASP.NET Core 5**.
- **Klaviyo API Integration**: Utilizes a custom service (`IEmailService`) to interact with Klaviyo's Track API.

## Prerequisites
- **Klaviyo API Key**: You will need a valid Klaviyo API key for API requests.
- **ASP.NET Core 5 SDK**: Ensure that the .NET 5 SDK is installed on your machine.

## Project Structure
```
KlaviyoPrototype/
│
├── Controllers/
│   └── EmailController.cs  # Contains the logic for sending email events.
│
├── Interface/
│   └── IEmailService.cs    # Interface for the email service.
│
├── Services/
│   └── EmailService.cs     # Logic for interacting with the Klaviyo API.
│
└── Program.cs              # Entry point for the application.
```

## Installation & Setup
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repo/klaviyo-custom-field-prototype.git
   cd klaviyo-custom-field-prototype
   ```

2. **Configure Klaviyo API Key**: Open the `EmailService.cs` file and replace the placeholder with your Klaviyo API key.

3. **Build the Project**:
   ```bash
   dotnet build
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

   This will launch the ASP.NET Core API on the default port (typically `http://localhost:5000`).

## Setting Up Klaviyo

### Create a Flow
1. **Log into Klaviyo**: Go to your Klaviyo account.
2. **Navigate to Flows**: Click on the "Flows" tab in the sidebar.
3. **Create a New Flow**: Click "Create Flow" and choose "Create from Scratch."
4. **Add a Trigger**: Select "Metric Trigger" and choose the event you want to track (e.g., `order_placed`).
5. **Configure the Flow**: Add actions like sending an email after the trigger.

### Create an Email Template
1. **Go to Templates**: Click on the "Email Templates" tab.
2. **Create a New Template**: Click "Create Template" and select a layout or start from scratch.
3. **Design Your Email**: Use the drag-and-drop editor to customize your email content.
4. **Save Your Template**: Once satisfied, save the template for use in your flow.

### Email HTML Template
An HTML email template is included in the project folder as `emailBody.html`. You can customize it for order confirmations.

## API Endpoint

### POST `/api/email/send`
Use this endpoint to send customer details.

#### Request Parameters:
- **Email** *(string)*: The recipient's email address.
- **FirstName** *(string)*: Customer's first name.
- **LastName** *(string)*: Customer's last name.
- **OrderNumber** *(string)*: Unique order identifier.
- **ItemList** *(array)*: List of items ordered with details.

#### Example Request:
```json
{
  "Email": "sao@smthgoodco.com",
  "FirstName": "Sao Bran",
  "LastName": "Aung",
  "OrderNumber": "ORD123456789",
  "ItemList": [
    {"ProductName": "Smartphone", "Quantity": 1, "Price": 699.99},
    {"ProductName": "Headphones", "Quantity": 2, "Price": 99.99}
  ]
}
```

#### Example Response:
```json
{
  "message": "Email event sent!"
}
```

## Customization
You can change the event name and fields in the `EmailController.cs` file.

## Contribution
Feel free to contribute by submitting issues or pull requests.

## License
This project is licensed under the MIT License.

## Contact
For support, please reach out to Sak Bran or open an issue in the repository.
