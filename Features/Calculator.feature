Feature: Test

Scenario: A upload file
Given user information
When upload file
Then result

Scenario: B getfilemetadata
Given file existence check
When get file metadata
Then output metadata

Scenario: C delete file
Given file existence check
When delete file
Then message of delete