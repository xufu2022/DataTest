# nullabilty of foreign keys

For a required relationship, EF Core sets the OnDelete action to **Cascade**. If the principal entity is deleted, the dependent entity will be deleted too.

For a optional relationship, EF Core sets the OnDelete action to ClientSetNull. If the dependent entity is being tracked, the foreign key will be set to null when the principal entity is deleted. But if the dependent entity isn’t being tracked, the database constraint delete setting takes over, and the ClientSetNull setting sets the database rules as though the **Restrict** setting were in place. The result is that the delete fails at the database level, and an exception is thrown

