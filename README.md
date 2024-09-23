
# Klaviyo Custom Field Testing - README

## Overview
This project is a prototype API for sending custom field data to Klaviyo using its Track API, built on **ASP.NET Core 5**. It allows you to send custom events such as `order_placed`, along with user-specific properties, to Klaviyo for tracking and analytics.

The primary controller in this project is the `EmailController`, which accepts email addresses and sends custom event data to Klaviyo.

## Key Features
- **Custom Event Tracking**: Sends an event (`order_placed`) to Klaviyo with custom fields like `order_id`, `customer_name`, and `order_items`.
- **ASP.NET Core 5**: This project is developed using **ASP.NET Core 5**.
- **Klaviyo API Integration**: Utilizes a custom service (`IEmailService`) to interact with Klaviyo's Track API.
  
## Prerequisites
- **Klaviyo API Key**: You will need a valid Klaviyo API key to make API requests.
- **ASP.NET Core 5 SDK**: Ensure that the .NET 5 SDK is installed on your machine.
  
## Project Structure

```
KlaviyoPrototype/
│
├── Controllers/
│   └── EmailController.cs  # Contains the main logic for sending email events.
│
├── Interface/
│   └── IEmailService.cs    # Interface for the email service.
│
├── Services/
│   └── EmailService.cs     # Contains the logic for interacting with the Klaviyo API.
│
└── Program.cs              # Entry point for the application.
```

## Installation & Setup

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repo/klaviyo-custom-field-prototype.git
   cd klaviyo-custom-field-prototype
   ```

2. **Configure Klaviyo API Key**:
   Open the `EmailService.cs` file and replace the placeholder with your Klaviyo API key.

3. **Build the Project**:
   ```bash
   dotnet build
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

   This will launch the ASP.NET Core API on the default port (typically `http://localhost:5000`).

## API Endpoints

### POST `/api/email/send`
Sends an email event to Klaviyo with a random `order_id`, `customer_name`, and `order_items`.

#### Request Parameters:
- **email** *(string)*: The recipient's email address.

#### Example Request:
```http
POST /api/email/send?email=test@example.com
```

#### Example Response:
```json
{
  "message": "Email event sent!"
}
```

### Example Custom Fields Sent to Klaviyo
```json
{
  "order_id": 12345,
  "value": 12345,
  "customer_name": "James Bond12345",
  "order_items": [
    "item1-12345",
    "item2-12345"
  ]
}
```

## Customization
You can modify the event name, custom fields, and other properties within the `SendEmail` method in the `EmailController.cs` file.

```csharp
var eventName = "order_placed";  // Change to your desired event name
```

Feel free to update the `properties` object to include additional fields relevant to your application.

## Dependencies
- **ASP.NET Core 5**: Web framework for building the API.
- **Klaviyo**: Integration with the Klaviyo Track API.

## Contribution
Feel free to contribute by opening issues or submitting pull requests. Make sure to follow best practices and guidelines.

## License
This project is licensed under the MIT License.

---

## Contact
For any issues or support, please contact Sak Bran or open an issue in the repository.
