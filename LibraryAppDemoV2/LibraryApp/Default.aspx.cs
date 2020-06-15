using LibraryApp.BusinessLogic;
using LibraryApp.BusinessObjects.Entities;
using LibraryApp.Utils;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryApp
{
    public partial class _Default : Page
    {
        //  DataTable bookTable;
        List<BookBO> bookTable;

         #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Common.sessionBookList] == null)
            {
                SetGridData();
            }

            if (!IsPostBack)
            {
                FillGrid();
            }

        }

        protected void gvBookList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
             
                BookBL bookBL = new BookBL();
                BookBO book = new BookBO();
                book = GetUpdateObject(book, e.RowIndex);

                bookTable = bookBL.Update(book, bookTable);

                Session[Common.sessionBookList] = bookTable;
                gvBookList.EditIndex = -1;
                FillGrid();
                lblSuccessMessage.Text = Common.msgUpdateSuccess;

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = Common.msgUpdateFailure;
            }

        }

        protected void gvBookList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBookList.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void gvBookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                bookTable = (List<BookBO>)Session[Common.sessionBookList];
                BookBL bookBL = new BookBL();

                bookTable = bookBL.DeleteById(gvBookList.DataKeys[e.RowIndex].Values[0], bookTable);
                Session["BooksList"] = bookTable;
                FillGrid();
                lblSuccessMessage.Text = Common.msgDeleteSuccess;
            }
            catch (Exception ex)
            {
                // log exception
                lblErrorMessage.Text = Common.msgDeleteFailure;
            }
        }

        protected void gvBookList_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void gvBookList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBookList.EditIndex = -1;
            FillGrid();
        }
        #endregion

        #region methods

        /// <summary>
        /// Fills the Grid and bind 
        /// </summary>
        private void FillGrid()
        {
            bookTable = (List<BookBO>)Session[Common.sessionBookList];
            gvBookList.DataSource = bookTable;
            gvBookList.DataBind();
        }
        /// <summary>
        /// Set initial Grid Data
        /// </summary>
        private void SetGridData()
        {
            Session[Common.sessionBookList] = bookTable;
            Session["bookId"] = 1;
        }
        #endregion

        protected void Insert(object sender, EventArgs e)
        {
            try
            {
                BookBL bookBL = new BookBL();
                BookBO book = new BookBO();

                book = GetBookObject(book);


                bookTable = (List<BookBO>)Session[Common.sessionBookList];
                if (bookTable == null)
                    bookTable = new List<BookBO>();

                bookTable = bookBL.Add(book, bookTable);

                Session[Common.sessionBookList] = bookTable;

                Session["bookId"] = book.Id + 1;

                gvBookList.EditIndex = -1;
                FillGrid();

                lblSuccessMessage.Text = Common.msgAddSuccess;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = Common.msgAddFailure;
            }
        }

        private BookBO GetBookObject(BookBO book)
        {
            try
            {
                book.Name = string.IsNullOrEmpty(txtName.Text) == true ? string.Empty : txtName.Text.Trim();
                book.Price = string.IsNullOrEmpty(txtPrice.Text) == true ? 0 : Convert.ToDouble(txtPrice.Text.Trim());
                book.Id = (int)Session["bookId"];
                return book;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = Common.msgAddFailure;
                return null;
            }
        }

        private BookBO GetUpdateObject(BookBO book, int index)
        {
            bookTable = (List<BookBO>)Session[Common.sessionBookList];
            TextBox txtName = (TextBox)gvBookList.Rows[index].FindControl("txtName");
            TextBox txtPrice = (TextBox)gvBookList.Rows[index].FindControl("txtPrice");

            book.Name = string.IsNullOrEmpty(txtName.Text) == true ? string.Empty : txtName.Text.Trim();
            book.Price = string.IsNullOrEmpty(txtPrice.Text) == true ? 0 : Convert.ToDouble(txtPrice.Text.Trim());
            book.Id = Convert.ToInt32(gvBookList.DataKeys[index].Values[0]);
            return book;
        }
    }
}