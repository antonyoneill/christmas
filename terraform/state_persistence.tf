resource "aws_s3_bucket" "terraform_state" {
  bucket = "antonyoneill-christmas-terraform-state"

  versioning {
    enabled = true
  }

  server_side_encryption_configuration {
    rule {
      apply_server_side_encryption_by_default {
        sse_algorithm = "AES256"
      }
    }
  }
}

terraform {
  backend "s3" {
    bucket = "antonyoneill-christmas-terraform-state"
    key = "terraform.tfstate"
    region = "eu-west-2"

  }
}
