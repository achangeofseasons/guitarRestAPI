﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace guitarRestAPI
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GuitarSample")]
	public partial class guitarSampleDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertguitar_brand(guitar_brand instance);
    partial void Updateguitar_brand(guitar_brand instance);
    partial void Deleteguitar_brand(guitar_brand instance);
    partial void Insertguitar_model(guitar_model instance);
    partial void Updateguitar_model(guitar_model instance);
    partial void Deleteguitar_model(guitar_model instance);
    #endregion
		
		public guitarSampleDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["GuitarSampleConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public guitarSampleDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public guitarSampleDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public guitarSampleDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public guitarSampleDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<guitar_brand> guitar_brands
		{
			get
			{
				return this.GetTable<guitar_brand>();
			}
		}
		
		public System.Data.Linq.Table<guitar_model> guitar_models
		{
			get
			{
				return this.GetTable<guitar_model>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.guitar_brand")]
	public partial class guitar_brand : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _guitar_brand_id;
		
		private string _name;
		
		private EntitySet<guitar_model> _guitar_models;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onguitar_brand_idChanging(int value);
    partial void Onguitar_brand_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public guitar_brand()
		{
			this._guitar_models = new EntitySet<guitar_model>(new Action<guitar_model>(this.attach_guitar_models), new Action<guitar_model>(this.detach_guitar_models));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_guitar_brand_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int guitar_brand_id
		{
			get
			{
				return this._guitar_brand_id;
			}
			set
			{
				if ((this._guitar_brand_id != value))
				{
					this.Onguitar_brand_idChanging(value);
					this.SendPropertyChanging();
					this._guitar_brand_id = value;
					this.SendPropertyChanged("guitar_brand_id");
					this.Onguitar_brand_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="guitar_brand_guitar_model", Storage="_guitar_models", ThisKey="guitar_brand_id", OtherKey="guitar_brand_id")]
		public EntitySet<guitar_model> guitar_models
		{
			get
			{
				return this._guitar_models;
			}
			set
			{
				this._guitar_models.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_guitar_models(guitar_model entity)
		{
			this.SendPropertyChanging();
			entity.guitar_brand = this;
		}
		
		private void detach_guitar_models(guitar_model entity)
		{
			this.SendPropertyChanging();
			entity.guitar_brand = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.guitar_model")]
	public partial class guitar_model : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _guitar_model_id;
		
		private int _guitar_brand_id;
		
		private string _name;
		
		private decimal _price;
		
		private EntityRef<guitar_brand> _guitar_brand;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onguitar_model_idChanging(int value);
    partial void Onguitar_model_idChanged();
    partial void Onguitar_brand_idChanging(int value);
    partial void Onguitar_brand_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnpriceChanging(decimal value);
    partial void OnpriceChanged();
    #endregion
		
		public guitar_model()
		{
			this._guitar_brand = default(EntityRef<guitar_brand>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_guitar_model_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int guitar_model_id
		{
			get
			{
				return this._guitar_model_id;
			}
			set
			{
				if ((this._guitar_model_id != value))
				{
					this.Onguitar_model_idChanging(value);
					this.SendPropertyChanging();
					this._guitar_model_id = value;
					this.SendPropertyChanged("guitar_model_id");
					this.Onguitar_model_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_guitar_brand_id", DbType="Int NOT NULL")]
		public int guitar_brand_id
		{
			get
			{
				return this._guitar_brand_id;
			}
			set
			{
				if ((this._guitar_brand_id != value))
				{
					if (this._guitar_brand.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onguitar_brand_idChanging(value);
					this.SendPropertyChanging();
					this._guitar_brand_id = value;
					this.SendPropertyChanged("guitar_brand_id");
					this.Onguitar_brand_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Money NOT NULL")]
		public decimal price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="guitar_brand_guitar_model", Storage="_guitar_brand", ThisKey="guitar_brand_id", OtherKey="guitar_brand_id", IsForeignKey=true)]
		public guitar_brand guitar_brand
		{
			get
			{
				return this._guitar_brand.Entity;
			}
			set
			{
				guitar_brand previousValue = this._guitar_brand.Entity;
				if (((previousValue != value) 
							|| (this._guitar_brand.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._guitar_brand.Entity = null;
						previousValue.guitar_models.Remove(this);
					}
					this._guitar_brand.Entity = value;
					if ((value != null))
					{
						value.guitar_models.Add(this);
						this._guitar_brand_id = value.guitar_brand_id;
					}
					else
					{
						this._guitar_brand_id = default(int);
					}
					this.SendPropertyChanged("guitar_brand");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
