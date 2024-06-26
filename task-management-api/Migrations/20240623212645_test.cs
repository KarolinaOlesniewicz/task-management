using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_management_api.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationTraget_notifications_NotificationId",
                table: "NotificationTraget");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationTraget_users_UserId",
                table: "NotificationTraget");

            migrationBuilder.DropForeignKey(
                name: "FK_activities_boards_BoardID",
                table: "activities");

            migrationBuilder.DropForeignKey(
                name: "FK_activities_tasks_TaskId",
                table: "activities");

            migrationBuilder.DropForeignKey(
                name: "FK_activities_users_User2Id",
                table: "activities");

            migrationBuilder.DropForeignKey(
                name: "FK_activities_users_UserId",
                table: "activities");

            migrationBuilder.DropForeignKey(
                name: "FK_assignments_tasks_TaskId",
                table: "assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_assignments_users_UserId",
                table: "assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_boardMembers_boards_BoardId",
                table: "boardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_boardMembers_users_UserId",
                table: "boardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_boards_workspaces_WorkspaceId",
                table: "boards");

            migrationBuilder.DropForeignKey(
                name: "FK_checklistElements_checklists_ChecklistId",
                table: "checklistElements");

            migrationBuilder.DropForeignKey(
                name: "FK_checklists_tasks_TaskId",
                table: "checklists");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_tasks_TaskId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_labels_colors_ColorId",
                table: "labels");

            migrationBuilder.DropForeignKey(
                name: "FK_labels_tasks_TaskId",
                table: "labels");

            migrationBuilder.DropForeignKey(
                name: "FK_lists_boards_BoardId",
                table: "lists");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_users_UserId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_observations_tasks_TaskId",
                table: "observations");

            migrationBuilder.DropForeignKey(
                name: "FK_observations_users_UserId",
                table: "observations");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_boards_BoardId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_lists_ListId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_workspaceMembers_users_UserId",
                table: "workspaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_workspaceMembers_workspaceRoles_RoleId",
                table: "workspaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_workspaceMembers_workspaces_WorkspaceId",
                table: "workspaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_workspaces_users_OwnerId",
                table: "workspaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workspaces",
                table: "workspaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workspaceRoles",
                table: "workspaceRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workspaceMembers",
                table: "workspaceMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_observations",
                table: "observations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notifications",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lists",
                table: "lists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_labels",
                table: "labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colors",
                table: "colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_checklists",
                table: "checklists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_checklistElements",
                table: "checklistElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boards",
                table: "boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boardMembers",
                table: "boardMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assignments",
                table: "assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_activities",
                table: "activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTraget",
                table: "NotificationTraget");

            migrationBuilder.RenameTable(
                name: "workspaces",
                newName: "Workspaces");

            migrationBuilder.RenameTable(
                name: "workspaceRoles",
                newName: "WorkspaceRoles");

            migrationBuilder.RenameTable(
                name: "workspaceMembers",
                newName: "WorkspaceMembers");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "observations",
                newName: "Observations");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "lists",
                newName: "Lists");

            migrationBuilder.RenameTable(
                name: "labels",
                newName: "Labels");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "colors",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "checklists",
                newName: "Checklists");

            migrationBuilder.RenameTable(
                name: "checklistElements",
                newName: "ChecklistElements");

            migrationBuilder.RenameTable(
                name: "boards",
                newName: "Boards");

            migrationBuilder.RenameTable(
                name: "boardMembers",
                newName: "BoardMembers");

            migrationBuilder.RenameTable(
                name: "assignments",
                newName: "Assignments");

            migrationBuilder.RenameTable(
                name: "activities",
                newName: "Activities");

            migrationBuilder.RenameTable(
                name: "NotificationTraget",
                newName: "NotificationTargets");

            migrationBuilder.RenameIndex(
                name: "IX_workspaces_OwnerId",
                table: "Workspaces",
                newName: "IX_Workspaces_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_workspaceMembers_WorkspaceId",
                table: "WorkspaceMembers",
                newName: "IX_WorkspaceMembers_WorkspaceId");

            migrationBuilder.RenameIndex(
                name: "IX_workspaceMembers_UserId",
                table: "WorkspaceMembers",
                newName: "IX_WorkspaceMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_workspaceMembers_RoleId",
                table: "WorkspaceMembers",
                newName: "IX_WorkspaceMembers_RoleId");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "Tasks",
                newName: "ListID");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Tasks",
                newName: "BoardID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_ListId",
                table: "Tasks",
                newName: "IX_Tasks_ListID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_BoardId",
                table: "Tasks",
                newName: "IX_Tasks_BoardID");

            migrationBuilder.RenameIndex(
                name: "IX_observations_UserId",
                table: "Observations",
                newName: "IX_Observations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_observations_TaskId",
                table: "Observations",
                newName: "IX_Observations_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_lists_BoardId",
                table: "Lists",
                newName: "IX_Lists_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_labels_TaskId",
                table: "Labels",
                newName: "IX_Labels_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_labels_ColorId",
                table: "Labels",
                newName: "IX_Labels_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_TaskId",
                table: "Comments",
                newName: "IX_Comments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_checklists_TaskId",
                table: "Checklists",
                newName: "IX_Checklists_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_checklistElements_ChecklistId",
                table: "ChecklistElements",
                newName: "IX_ChecklistElements_ChecklistId");

            migrationBuilder.RenameIndex(
                name: "IX_boards_WorkspaceId",
                table: "Boards",
                newName: "IX_Boards_WorkspaceId");

            migrationBuilder.RenameIndex(
                name: "IX_boardMembers_UserId",
                table: "BoardMembers",
                newName: "IX_BoardMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_boardMembers_BoardId",
                table: "BoardMembers",
                newName: "IX_BoardMembers_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_assignments_UserId",
                table: "Assignments",
                newName: "IX_Assignments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assignments_TaskId",
                table: "Assignments",
                newName: "IX_Assignments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_activities_UserId",
                table: "Activities",
                newName: "IX_Activities_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_activities_User2Id",
                table: "Activities",
                newName: "IX_Activities_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_activities_TaskId",
                table: "Activities",
                newName: "IX_Activities_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_activities_BoardID",
                table: "Activities",
                newName: "IX_Activities_BoardID");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationTraget_UserId",
                table: "NotificationTargets",
                newName: "IX_NotificationTargets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationTraget_NotificationId",
                table: "NotificationTargets",
                newName: "IX_NotificationTargets_NotificationId");

            migrationBuilder.AddColumn<int>(
                name: "MilestoneID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityID",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workspaces",
                table: "Workspaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkspaceRoles",
                table: "WorkspaceRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkspaceMembers",
                table: "WorkspaceMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Observations",
                table: "Observations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lists",
                table: "Lists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChecklistElements",
                table: "ChecklistElements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardMembers",
                table: "BoardMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTargets",
                table: "NotificationTargets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    URL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milestones_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Priorities_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaskLabels",
                columns: table => new
                {
                    TaskLabelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLabels", x => x.TaskLabelId);
                    table.ForeignKey(
                        name: "FK_TaskLabels_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskLabels_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MilestoneID",
                table: "Tasks",
                column: "MilestoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityID",
                table: "Tasks",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TaskId",
                table: "Attachments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_UserId",
                table: "Attachments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_MeetingId",
                table: "Attendees",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_UserId",
                table: "Attendees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_BoardId",
                table: "Meetings",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_UserId",
                table: "Meetings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestones_BoardId",
                table: "Milestones",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Priorities_ColorId",
                table: "Priorities",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLabels_LabelId",
                table: "TaskLabels",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLabels_TaskId",
                table: "TaskLabels",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OwnerId",
                table: "Teams",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Boards_BoardID",
                table: "Activities",
                column: "BoardID",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_TaskId",
                table: "Activities",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_User2Id",
                table: "Activities",
                column: "User2Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Tasks_TaskId",
                table: "Assignments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_UserId",
                table: "Assignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Boards_BoardId",
                table: "BoardMembers",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Workspaces_WorkspaceId",
                table: "Boards",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistElements_Checklists_ChecklistId",
                table: "ChecklistElements",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_Tasks_TaskId",
                table: "Checklists",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Colors_ColorId",
                table: "Labels",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Tasks_TaskId",
                table: "Labels",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Boards_BoardId",
                table: "Lists",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTargets_Notifications_NotificationId",
                table: "NotificationTargets",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTargets_Users_UserId",
                table: "NotificationTargets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Tasks_TaskId",
                table: "Observations",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Users_UserId",
                table: "Observations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardID",
                table: "Tasks",
                column: "BoardID",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lists_ListID",
                table: "Tasks",
                column: "ListID",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Milestones_MilestoneID",
                table: "Tasks",
                column: "MilestoneID",
                principalTable: "Milestones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Priorities_PriorityID",
                table: "Tasks",
                column: "PriorityID",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspaceMembers_Users_UserId",
                table: "WorkspaceMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspaceMembers_WorkspaceRoles_RoleId",
                table: "WorkspaceMembers",
                column: "RoleId",
                principalTable: "WorkspaceRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspaceMembers_Workspaces_WorkspaceId",
                table: "WorkspaceMembers",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workspaces_Users_OwnerId",
                table: "Workspaces",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Boards_BoardID",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_TaskId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_User2Id",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_UserId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Tasks_TaskId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_UserId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Boards_BoardId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Workspaces_WorkspaceId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistElements_Checklists_ChecklistId",
                table: "ChecklistElements");

            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_Tasks_TaskId",
                table: "Checklists");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Colors_ColorId",
                table: "Labels");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Tasks_TaskId",
                table: "Labels");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Boards_BoardId",
                table: "Lists");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationTargets_Notifications_NotificationId",
                table: "NotificationTargets");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationTargets_Users_UserId",
                table: "NotificationTargets");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Tasks_TaskId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Users_UserId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_ListID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Milestones_MilestoneID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Priorities_PriorityID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkspaceMembers_Users_UserId",
                table: "WorkspaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkspaceMembers_WorkspaceRoles_RoleId",
                table: "WorkspaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkspaceMembers_Workspaces_WorkspaceId",
                table: "WorkspaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workspaces_Users_OwnerId",
                table: "Workspaces");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Milestones");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "TaskLabels");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workspaces",
                table: "Workspaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkspaceRoles",
                table: "WorkspaceRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkspaceMembers",
                table: "WorkspaceMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MilestoneID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PriorityID",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Observations",
                table: "Observations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lists",
                table: "Lists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChecklistElements",
                table: "ChecklistElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardMembers",
                table: "BoardMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTargets",
                table: "NotificationTargets");

            migrationBuilder.DropColumn(
                name: "MilestoneID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PriorityID",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Workspaces",
                newName: "workspaces");

            migrationBuilder.RenameTable(
                name: "WorkspaceRoles",
                newName: "workspaceRoles");

            migrationBuilder.RenameTable(
                name: "WorkspaceMembers",
                newName: "workspaceMembers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "tasks");

            migrationBuilder.RenameTable(
                name: "Observations",
                newName: "observations");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "Lists",
                newName: "lists");

            migrationBuilder.RenameTable(
                name: "Labels",
                newName: "labels");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "colors");

            migrationBuilder.RenameTable(
                name: "Checklists",
                newName: "checklists");

            migrationBuilder.RenameTable(
                name: "ChecklistElements",
                newName: "checklistElements");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "boards");

            migrationBuilder.RenameTable(
                name: "BoardMembers",
                newName: "boardMembers");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "assignments");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "activities");

            migrationBuilder.RenameTable(
                name: "NotificationTargets",
                newName: "NotificationTraget");

            migrationBuilder.RenameIndex(
                name: "IX_Workspaces_OwnerId",
                table: "workspaces",
                newName: "IX_workspaces_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkspaceMembers_WorkspaceId",
                table: "workspaceMembers",
                newName: "IX_workspaceMembers_WorkspaceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkspaceMembers_UserId",
                table: "workspaceMembers",
                newName: "IX_workspaceMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkspaceMembers_RoleId",
                table: "workspaceMembers",
                newName: "IX_workspaceMembers_RoleId");

            migrationBuilder.RenameColumn(
                name: "ListID",
                table: "tasks",
                newName: "ListId");

            migrationBuilder.RenameColumn(
                name: "BoardID",
                table: "tasks",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ListID",
                table: "tasks",
                newName: "IX_tasks_ListId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_BoardID",
                table: "tasks",
                newName: "IX_tasks_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_UserId",
                table: "observations",
                newName: "IX_observations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_TaskId",
                table: "observations",
                newName: "IX_observations_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "notifications",
                newName: "IX_notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Lists_BoardId",
                table: "lists",
                newName: "IX_lists_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_TaskId",
                table: "labels",
                newName: "IX_labels_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_ColorId",
                table: "labels",
                newName: "IX_labels_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "comments",
                newName: "IX_comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TaskId",
                table: "comments",
                newName: "IX_comments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Checklists_TaskId",
                table: "checklists",
                newName: "IX_checklists_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistElements_ChecklistId",
                table: "checklistElements",
                newName: "IX_checklistElements_ChecklistId");

            migrationBuilder.RenameIndex(
                name: "IX_Boards_WorkspaceId",
                table: "boards",
                newName: "IX_boards_WorkspaceId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardMembers_UserId",
                table: "boardMembers",
                newName: "IX_boardMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardMembers_BoardId",
                table: "boardMembers",
                newName: "IX_boardMembers_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_UserId",
                table: "assignments",
                newName: "IX_assignments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_TaskId",
                table: "assignments",
                newName: "IX_assignments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_UserId",
                table: "activities",
                newName: "IX_activities_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_User2Id",
                table: "activities",
                newName: "IX_activities_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_TaskId",
                table: "activities",
                newName: "IX_activities_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_BoardID",
                table: "activities",
                newName: "IX_activities_BoardID");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationTargets_UserId",
                table: "NotificationTraget",
                newName: "IX_NotificationTraget_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationTargets_NotificationId",
                table: "NotificationTraget",
                newName: "IX_NotificationTraget_NotificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workspaces",
                table: "workspaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workspaceRoles",
                table: "workspaceRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workspaceMembers",
                table: "workspaceMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                table: "tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_observations",
                table: "observations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notifications",
                table: "notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lists",
                table: "lists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_labels",
                table: "labels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colors",
                table: "colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_checklists",
                table: "checklists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_checklistElements",
                table: "checklistElements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boards",
                table: "boards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boardMembers",
                table: "boardMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignments",
                table: "assignments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_activities",
                table: "activities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTraget",
                table: "NotificationTraget",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTraget_notifications_NotificationId",
                table: "NotificationTraget",
                column: "NotificationId",
                principalTable: "notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTraget_users_UserId",
                table: "NotificationTraget",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_activities_boards_BoardID",
                table: "activities",
                column: "BoardID",
                principalTable: "boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_activities_tasks_TaskId",
                table: "activities",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_activities_users_User2Id",
                table: "activities",
                column: "User2Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_activities_users_UserId",
                table: "activities",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_tasks_TaskId",
                table: "assignments",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_users_UserId",
                table: "assignments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_boardMembers_boards_BoardId",
                table: "boardMembers",
                column: "BoardId",
                principalTable: "boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_boardMembers_users_UserId",
                table: "boardMembers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_boards_workspaces_WorkspaceId",
                table: "boards",
                column: "WorkspaceId",
                principalTable: "workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_checklistElements_checklists_ChecklistId",
                table: "checklistElements",
                column: "ChecklistId",
                principalTable: "checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_checklists_tasks_TaskId",
                table: "checklists",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_tasks_TaskId",
                table: "comments",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_labels_colors_ColorId",
                table: "labels",
                column: "ColorId",
                principalTable: "colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_labels_tasks_TaskId",
                table: "labels",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lists_boards_BoardId",
                table: "lists",
                column: "BoardId",
                principalTable: "boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_users_UserId",
                table: "notifications",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_observations_tasks_TaskId",
                table: "observations",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_observations_users_UserId",
                table: "observations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_boards_BoardId",
                table: "tasks",
                column: "BoardId",
                principalTable: "boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_lists_ListId",
                table: "tasks",
                column: "ListId",
                principalTable: "lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspaceMembers_users_UserId",
                table: "workspaceMembers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspaceMembers_workspaceRoles_RoleId",
                table: "workspaceMembers",
                column: "RoleId",
                principalTable: "workspaceRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspaceMembers_workspaces_WorkspaceId",
                table: "workspaceMembers",
                column: "WorkspaceId",
                principalTable: "workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workspaces_users_OwnerId",
                table: "workspaces",
                column: "OwnerId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
