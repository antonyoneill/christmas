terraform {
  required_providers {
    twilio = {
      source = "RJPearson94/twilio"
      version = ">= 0.2.1"
    }
  }
}

variable "twilio_account_sid" {}
variable "twilio_api_key" {}
variable "twilio_api_secret" {}
variable "incoming_phone_number" {}

provider "twilio" {
  account_sid = var.twilio_account_sid 
  api_key     = var.twilio_api_key
  api_secret  = var.twilio_api_secret
}

resource "twilio_phone_number" "phone_number" {
  account_sid  = var.twilio_account_sid
  phone_number = var.incoming_phone_number
}
