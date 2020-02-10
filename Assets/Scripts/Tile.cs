﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	private Material material;
	private bool isWall = false;
	private float alpha = 0.3f;
	private Vector2 pos;

	private int gCost;
	private int hCost;
	private Tile previous;

	public bool isPath = false;

	public void Awake() {
		material = GetComponent<Renderer>().material;
	}

	public void Update() {
		if (isPath) {
			SetColor(new Color(0, 0, 1, alpha));
		} else if (isWall) {
			SetColor(new Color(1, 0, 0, alpha));
		} else {
			SetColor(new Color(1, 1, 1, alpha));			
		}
	}

	public void SetPos(Vector2 pos) {
		this.pos = pos;
	}

	public Vector2 GetPos() {
		return pos;
	}

	public int Fcost() {
		return gCost + hCost;
	}

	public int Hcost() {
		return hCost;
	}
	public void SetH(int value) {
		hCost = value;
	}
	public int Gcost() {
		return gCost;
	}
	public void SetG(int value) {
		gCost = value;
	}

	public Tile Previous() {
		return previous;
	}
	public void SetPrevious(Tile tile) {
		previous = tile; 
	}

	public bool IsWall() {
		return isWall;
	}

	public void Reset() {
		gCost = 0;
		hCost = 0;
		previous = null;
		isPath = false;		
	}

	public void OnTriggerStay(Collider other) {
		if (CollisionController.IsIgnored(other.tag)) {	
			return;
		}
		isWall = true;
	}

	public void OnTriggerExit() {
		isWall = false;
	}

	public void SetColor(Color color) {
		material.SetColor("_Color", color);
	}

	public override bool Equals(object obj) {
		Tile other = (Tile)obj;
		return pos.Equals(other.pos);
	}

	public override int GetHashCode() {
		int hash = 13;
		hash = (hash * 7) + pos.GetHashCode();
    	return hash;
	}
}